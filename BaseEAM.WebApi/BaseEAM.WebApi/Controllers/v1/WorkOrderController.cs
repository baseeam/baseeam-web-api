/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using BaseEAM.Core;
using BaseEAM.Core.Data;
using BaseEAM.Core.Domain;
using BaseEAM.Data;
using BaseEAM.Services;
using BaseEAM.WebApi.Extensions;
using BaseEAM.WebApi.Models;
using BaseEAM.WebApi.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace BaseEAM.WebApi.Controllers.v1
{
    public class WorkOrderController : ApiController
    {
        #region Fields

        private readonly IRepository<WorkOrder> _workOrderRepository;
        private readonly IRepository<WorkOrderTask> _workOrderTaskRepository;
        private readonly IRepository<WorkOrderItem> _workOrderItemRepository;
        private readonly IRepository<WorkOrderServiceItem> _workOrderServiceItemRepository;
        private readonly IRepository<WorkOrderMiscCost> _workOrderMiscCostRepository;
        private readonly IRepository<PointMeterLineItem> _pointMeterLineItemRepository;
        private readonly IRepository<Reading> _readingRepository;
        private readonly IRepository<ValueItemCategory> _valueItemCategoryRepository;
        private readonly IRepository<ValueItem> _valueItemRepository;
        private readonly IRepository<Code> _codeRepository;
        private readonly IRepository<WorkOrderLabor> _workOrderLaborRepository;
        private readonly IRepository<Craft> _craftRepository;
        private readonly IRepository<UnitOfMeasure> _unitOfMeasureRepository;
        private readonly IRepository<MeterGroup> _meterGroupRepository;
        private readonly IRepository<Meter> _meterRepository;
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<Attachment> _attachmentRepository;
        private readonly ILocalizationService _localizationService;
        private readonly ISiteService _siteService;
        private readonly IUserService _userService;
        private readonly IWorkContext _workContext;
        private readonly IDbContext _dbContext;

        #endregion

        #region Constructors

        public WorkOrderController(IRepository<WorkOrder> workOrderRepository,
            IRepository<WorkOrderTask> workOrderTaskRepository,
            IRepository<WorkOrderItem> workOrderItemRepository,
            IRepository<WorkOrderServiceItem> workOrderServiceItemRepository,
            IRepository<WorkOrderMiscCost> workOrderMiscCostRepository,
            IRepository<PointMeterLineItem> pointMeterLineItemRepository,
            IRepository<Reading> readingRepository,
            IRepository<ValueItemCategory> valueItemCategoryRepository,
            IRepository<ValueItem> valueItemRepository,
            IRepository<Code> codeRepository,
            IRepository<WorkOrderLabor> workOrderLaborRepository,
            IRepository<Craft> craftRepository,
            IRepository<UnitOfMeasure> unitOfMeasureRepository,
            IRepository<MeterGroup> meterGroupRepository,
            IRepository<Meter> meterRepository,
            IRepository<Comment> commentRepository,
            IRepository<Attachment> attachmentRepository,
            ILocalizationService localizationService,
            ISiteService siteService,
            IUserService userService,
            IWorkContext workContext,
            IDbContext dbContext)
        {
            this._workOrderRepository = workOrderRepository;
            this._workOrderTaskRepository = workOrderTaskRepository;
            this._workOrderItemRepository = workOrderItemRepository;
            this._workOrderServiceItemRepository = workOrderServiceItemRepository;
            this._workOrderMiscCostRepository = workOrderMiscCostRepository;
            this._pointMeterLineItemRepository = pointMeterLineItemRepository;
            this._readingRepository = readingRepository;
            this._valueItemCategoryRepository = valueItemCategoryRepository;
            this._valueItemRepository = valueItemRepository;
            this._codeRepository = codeRepository;
            this._workOrderLaborRepository = workOrderLaborRepository;
            this._craftRepository = craftRepository;
            this._unitOfMeasureRepository = unitOfMeasureRepository;
            this._meterGroupRepository = meterGroupRepository;
            this._meterRepository = meterRepository;
            this._commentRepository = commentRepository;
            this._attachmentRepository = attachmentRepository;
            this._localizationService = localizationService;
            this._siteService = siteService;
            this._userService = userService;
            this._workContext = workContext;
            this._dbContext = dbContext;
        }

        #endregion

        #region Methods

        [HttpGet]
        [WebApiAuthenticate]
        [Route("v1/workorder/downloadmywodataschema")]
        public MyWOData DownloadMyWODataSchema()
        {
            var data = new MyWOData();
            data.InitializeDataForSqlLiteSchema();
            return data;
        }

        [HttpGet]
        [WebApiAuthenticate]
        [Route("v1/workorder/downloadmywodata")]
        public MyWOData DownloadMyWOData([FromUri]DateTime? modifiedDateTime)
        {
            var data = new MyWOData();

            // we always get all WOs of this user
            // on the mobile, first we need to truncate all WO's related tables
            // before store the data returned.
            var workOrders = _workOrderRepository.GetAll()
                .Where(w => w.Assignment.Users.Any(u => u.Id == this._workContext.CurrentUser.Id))
                //.Include(w => w.WorkOrderTasks)
                //.Include(w => w.Assignment)
                //.Include(w => w.WorkOrderLabors)                
                //.Include(w => w.WorkOrderItems)
                //.Include(w => w.WorkOrderServiceItems)
                //.Include(w => w.WorkOrderMiscCosts)                
                .ToList();

            // Get My WOs
            data.WorkOrder = workOrders.Select(w => w.ToModel()).ToList();

            // Get My Assignments
            var assignments = workOrders.Select(w => w.Assignment).ToList();
            data.Assignment = assignments.Select(a => a.ToModel()).ToList();
            data.AssignmentUser = new List<AssignmentUserModel>();
            foreach(var a in assignments)
            {
                foreach (var u in a.Users)
                    data.AssignmentUser.Add(new AssignmentUserModel { AssignmentId = a.Id, UserId = u.Id });
            }

            // Get My WorkOrderLabors
            data.WorkOrderLabor = new List<WorkOrderLaborModel>();
            foreach(var wo in workOrders)
            {
                foreach (var wol in wo.WorkOrderLabors)
                    data.WorkOrderLabor.Add(wol.ToModel());
            }

            // Get My WorkOrderTasks
            data.WorkOrderTask = new List<WorkOrderTaskModel>();
            foreach (var wo in workOrders)
            {
                foreach (var wot in wo.WorkOrderTasks)
                    data.WorkOrderTask.Add(wot.ToModel());
            }

            // Get My WorkOrderItems
            data.WorkOrderItem = new List<WorkOrderItemModel>();
            foreach (var wo in workOrders)
            {
                foreach (var woi in wo.WorkOrderItems)
                    data.WorkOrderItem.Add(woi.ToModel());
            }

            // Get My WorkOrderServiceItems
            data.WorkOrderServiceItem = new List<WorkOrderServiceItemModel>();
            foreach (var wo in workOrders)
            {
                foreach (var wos in wo.WorkOrderServiceItems)
                    data.WorkOrderServiceItem.Add(wos.ToModel());
            }

            // Get My WorkOrderMiscCosts
            data.WorkOrderMiscCost = new List<WorkOrderMiscCostModel>();
            foreach (var wo in workOrders)
            {
                foreach (var wom in wo.WorkOrderMiscCosts)
                    data.WorkOrderMiscCost.Add(wom.ToModel());
            }

            // Get My Comments
            data.Comment = new List<CommentModel>();
            foreach(var wo in workOrders)
            {
                var comments = _commentRepository.GetAll()
                    .Where(c => c.EntityId == wo.Id && c.EntityType == EntityType.WorkOrder)
                    .ToList();
                foreach(var comment in comments)
                {
                    data.Comment.Add(comment.ToModel());
                }
            }

            // Get My Sites
            var sites = _siteService.GetSites(this._workContext.CurrentUser, modifiedDateTime);
            data.Site = sites.Select(s => s.ToModel()).ToList();

            // Get My Assets
            var assets = _siteService.GetAssets(this._workContext.CurrentUser, modifiedDateTime);
            data.Asset = assets.Select(s => s.ToModel()).ToList();

            // Get My Locations
            var locations = _siteService.GetLocations(this._workContext.CurrentUser, modifiedDateTime);
            data.Location = locations.Select(s => s.ToModel()).ToList();

            // Get all ValueItemCategory
            data.ValueItemCategory = _valueItemCategoryRepository.GetAll()
                .Where(v => v.ModifiedDateTime >= modifiedDateTime).ToList()
                .Select(v => v.ToModel()).ToList();

            // Get all ValueItem
            data.ValueItem = _valueItemRepository.GetAll()
                .Where(v => v.ModifiedDateTime >= modifiedDateTime).ToList()
                .Select(v => v.ToModel()).ToList();

            // Get all Code
            data.Code = _codeRepository.GetAll()
                .Where(v => v.ModifiedDateTime >= modifiedDateTime).ToList()
                .Select(v => v.ToModel()).ToList();

            // Get My Teams
            var teams = _siteService.GetTeams(this._workContext.CurrentUser, modifiedDateTime);
            data.Team = teams.Select(t => t.ToModel()).ToList();

            // Get My Users
            var users = _siteService.GetUsers(this._workContext.CurrentUser, modifiedDateTime);
            data.User = users.Select(s => s.ToModel()).ToList();

            // Get My Technicians
            var technicians = _siteService.GetTechnicians(this._workContext.CurrentUser, modifiedDateTime);
            data.Technician = technicians.Select(s => s.ToModel()).ToList();

            // Get TeamTechnician
            data.TeamTechnician = new List<TeamTechnicianModel>();
            foreach(var team in teams)
            {
                foreach(var technician in team.Technicians)
                {
                    data.TeamTechnician.Add(new TeamTechnicianModel
                    {
                        TeamId = team.Id,
                        TechnicianId = technician.Id
                    });
                }
            }

            // Get all Craft
            data.Craft = _craftRepository.GetAll()
                .Where(v => v.ModifiedDateTime >= modifiedDateTime).ToList()
                .Select(v => v.ToModel()).ToList();

            // Get all UnitOfMeasure
            data.UnitOfMeasure = _unitOfMeasureRepository.GetAll()
                .Where(v => v.ModifiedDateTime >= modifiedDateTime).ToList()
                .Select(v => v.ToModel()).ToList();

            // Get all MeterGroup
            var meterGroups = _meterGroupRepository.GetAll()
                .Where(v => v.ModifiedDateTime >= modifiedDateTime).Include(v => v.MeterLineItems).ToList();
            data.MeterGroup = meterGroups.Select(v => v.ToModel()).ToList();

            // Get all Meter
            data.Meter = _meterRepository.GetAll()
                .Where(v => v.ModifiedDateTime >= modifiedDateTime).ToList()
                .Select(v => v.ToModel()).ToList();

            // Get My MeterLineItems
            data.MeterLineItem = new List<MeterLineItemModel>();
            foreach (var mg in meterGroups)
            {
                foreach (var m in mg.MeterLineItems)
                    data.MeterLineItem.Add(m.ToModel());
            }

            // Get My Points
            var points = _siteService.GetPoints(this._workContext.CurrentUser, modifiedDateTime);
            data.Point = points.Select(s => s.ToModel()).ToList();

            // Get My PointMeterLineItems
            data.PointMeterLineItem = new List<PointMeterLineItemModel>();
            foreach (var p in points)
            {
                foreach (var pm in p.PointMeterLineItems)
                    data.PointMeterLineItem.Add(pm.ToModel());
            }

            // Get My Reading
            data.Reading = new List<ReadingModel>();

            data.ModifiedDateTime = DateTime.UtcNow;
            return data;
        }

        /// <summary>
        /// Resolve conflicts by Client-Win strategy
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Conflict Data</returns>
        [HttpPost]
        [WebApiAuthenticate]
        [Route("v1/workorder/uploadmyupdatedwodata")]
        public MyUpdatedWOData UploadMyUpdatedWOData([FromBody] MyUpdatedWOData data)
        {
            var conflict = new MyUpdatedWOData();
            try
            {
                foreach(var model in data.WorkOrder)
                {
                    var wo = _workOrderRepository.GetById(model.Id);
                    if(model.Version != wo.Version)
                    {
                        conflict.WorkOrder.Add(model);
                    }
                    // update
                    wo.ActualStartDateTime = model.ActualStartDateTime;
                    wo.ActualEndDateTime = model.ActualEndDateTime;
                    wo.ActualFailureGroupId = model.ActualFailureGroupId;
                    wo.ActualProblemId = model.ActualProblemId;
                    wo.ActualCauseId = model.ActualCauseId;
                    wo.ResolutionId = model.ResolutionId;
                    wo.ResolutionNotes = model.ResolutionNotes;

                    _workOrderRepository.Update(wo);
                }
                foreach (var model in data.WorkOrderLabor)
                {
                    var woLabor = _workOrderLaborRepository.GetById(model.Id);
                    if (model.Version != woLabor.Version)
                    {
                        conflict.WorkOrderLabor.Add(model);
                    }
                    //update
                    woLabor.ActualNormalHours = model.ActualNormalHours;
                    woLabor.ActualOTHours = model.ActualOTHours;
                    woLabor.ActualTotal = model.ActualTotal;

                    _workOrderLaborRepository.Update(woLabor);
                }
                foreach (var model in data.WorkOrderTask)
                {
                    var woTask = _workOrderTaskRepository.GetById(model.Id);
                    if (model.Version != woTask.Version)
                    {
                        conflict.WorkOrderTask.Add(model);
                    }
                    // update
                    woTask.Completed = model.Completed;
                    woTask.CompletedDate = model.CompletedDate;
                    woTask.CompletedUserId = this._workContext.CurrentUser.Id;
                    woTask.HoursSpent = model.HoursSpent;
                    woTask.Result = model.Result;
                    woTask.CompletionNotes = model.CompletionNotes;

                    _workOrderTaskRepository.Update(woTask);
                }
                foreach (var model in data.WorkOrderItem)
                {
                    var woItem = _workOrderItemRepository.GetById(model.Id);
                    if (model.Version != woItem.Version)
                    {
                        conflict.WorkOrderItem.Add(model);
                    }
                    // update
                    woItem.ActualQuantity = model.ActualQuantity;
                    woItem.ActualToolHours = model.ActualToolHours;
                    woItem.ActualTotal = model.ActualTotal;

                    _workOrderItemRepository.Update(woItem);
                }
                foreach (var model in data.WorkOrderServiceItem)
                {
                    var woServiceItem = _workOrderServiceItemRepository.GetById(model.Id);
                    if (model.Version != woServiceItem.Version)
                    {
                        conflict.WorkOrderServiceItem.Add(model);
                    }
                    // update
                    woServiceItem.ActualQuantity = model.ActualQuantity;
                    woServiceItem.ActualUnitPrice = model.ActualUnitPrice;
                    woServiceItem.ActualTotal = model.ActualTotal;

                    _workOrderServiceItemRepository.Update(woServiceItem);
                }
                foreach (var model in data.WorkOrderMiscCost)
                {
                    var woMiscCost = _workOrderMiscCostRepository.GetById(model.Id);
                    if (model.Version != woMiscCost.Version)
                    {
                        conflict.WorkOrderMiscCost.Add(model);
                    }
                    // update
                    woMiscCost.ActualQuantity = model.ActualQuantity;
                    woMiscCost.ActualUnitPrice = model.ActualUnitPrice;
                    woMiscCost.ActualTotal = model.ActualTotal;

                    _workOrderMiscCostRepository.Update(woMiscCost);
                }
                foreach (var model in data.Reading)
                {
                    var reading = new Reading
                    {
                        PointMeterLineItemId = model.PointMeterLineItemId,
                        ReadingValue = model.ReadingValue,
                        DateOfReading = model.DateOfReading,
                        ReadingSource = (int?)ReadingSource.WorkOrder,
                        WorkOrderId = model.WorkOrderId
                    };
                    _readingRepository.Insert(reading);
                }
                if(data.Reading.Count > 0)
                {
                    var lastReading = data.Reading.OrderByDescending(r => r.DateOfReading).ElementAt(0);
                    var p = _pointMeterLineItemRepository.GetById(lastReading.PointMeterLineItemId);
                    p.LastReadingValue = lastReading.ReadingValue;
                    p.LastDateOfReading = lastReading.DateOfReading;
                    p.LastReadingUser = this._workContext.CurrentUser.Name;
                    _pointMeterLineItemRepository.Update(p);
                }
                foreach (var model in data.Comment)
                {
                    var comment = new Comment
                    {
                        EntityId = model.EntityId,
                        EntityType = model.EntityType,
                        Message = model.Message
                    };
                    _commentRepository.Insert(comment);
                }
                foreach (var model in data.Attachment)
                {
                    var fileBinary = Convert.FromBase64String(model.ImageBase64String);
                    var attachment = new Attachment
                    {
                        FileBytes = fileBinary,
                        FileSize = fileBinary.Length,
                        ContentType = "image/png",
                        Extension = ".png",
                        Name = model.Name
                    };
                    attachment.EntityAttachments.Add(new EntityAttachment
                    {
                        EntityId = model.EntityId,
                        EntityType = model.EntityType
                    });
                    _attachmentRepository.Insert(attachment);
                }

                this._dbContext.SaveChanges();
            }
            catch(Exception)
            {
                conflict = null;
            }
            return conflict;
        }

        [HttpPost]
        [WebApiAuthenticate]
        [Route("v1/workorder/uploadattachment")]
        public AttachmentModel UploadAttachment([FromBody] AttachmentModel attachment)
        {
            return attachment;
        }

        #endregion
    }
}