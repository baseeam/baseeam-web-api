/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using System;
using System.Collections.Generic;

namespace BaseEAM.WebApi.Models
{
    public class MyWOData
    {
        public DateTime? ModifiedDateTime { get; set; }
        public List<WorkOrderModel> WorkOrder { get; set; }
        public List<WorkOrderLaborModel> WorkOrderLabor { get; set; }
        public List<WorkOrderTaskModel> WorkOrderTask { get; set; }
        public List<WorkOrderItemModel> WorkOrderItem { get; set; }
        public List<WorkOrderServiceItemModel> WorkOrderServiceItem { get; set; }
        public List<WorkOrderMiscCostModel> WorkOrderMiscCost { get; set; }
        public List<AssignmentModel> Assignment { get; set; }
        public List<AssignmentUserModel> AssignmentUser { get; set; }
        public List<SiteModel> Site { get; set; }
        public List<AssetModel> Asset { get; set; }
        public List<LocationModel> Location { get; set; }
        public List<ValueItemCategoryModel> ValueItemCategory { get; set; }
        public List<ValueItemModel> ValueItem { get; set; }
        public List<CodeModel> Code { get; set; }
        public List<TeamModel> Team { get; set; }
        public List<UserModel> User { get; set; }
        public List<TechnicianModel> Technician { get; set; }
        public List<TeamTechnicianModel> TeamTechnician { get; set; }
        public List<CraftModel> Craft { get; set; }
        public List<UnitOfMeasureModel> UnitOfMeasure { get; set; }
        public List<MeterGroupModel> MeterGroup { get; set; }
        public List<MeterModel> Meter { get; set; }
        public List<MeterLineItemModel> MeterLineItem { get; set; }
        public List<PointModel> Point { get; set; }
        public List<PointMeterLineItemModel> PointMeterLineItem { get; set; }
        public List<ReadingModel> Reading { get; set; }
        public List<CommentModel> Comment { get; set; }
        public List<AttachmentModel> Attachment { get; set; }

        public void InitializeDataForSqlLiteSchema()
        {
            ModifiedDateTime = DateTime.UtcNow;

            WorkOrder = new List<WorkOrderModel>();
            WorkOrder.Add(InitializeWorkOrder());

            WorkOrderLabor = new List<WorkOrderLaborModel>();
            WorkOrderLabor.Add(InitializeWorkOrderLabor());

            WorkOrderTask = new List<WorkOrderTaskModel>();
            WorkOrderTask.Add(InitializeWorkOrderTask());

            WorkOrderItem = new List<WorkOrderItemModel>();
            WorkOrderItem.Add(InitializeWorkOrderItem());

            WorkOrderServiceItem = new List<WorkOrderServiceItemModel>();
            WorkOrderServiceItem.Add(InitializeWorkOrderServiceItem());

            WorkOrderMiscCost = new List<WorkOrderMiscCostModel>();
            WorkOrderMiscCost.Add(InitializeWorkOrderMiscCost());

            Assignment = new List<AssignmentModel>();
            Assignment.Add(InitializeAssignment());

            AssignmentUser = new List<AssignmentUserModel>();
            AssignmentUser.Add(InitializeAssignmentUser());

            Site = new List<SiteModel>();
            Site.Add(InitializeSite());

            Asset = new List<AssetModel>();
            Asset.Add(InitializeAsset());

            Location = new List<LocationModel>();
            Location.Add(InitializeLocation());

            ValueItemCategory = new List<ValueItemCategoryModel>();
            ValueItemCategory.Add(InitializeValueItemCategory());

            ValueItem = new List<ValueItemModel>();
            ValueItem.Add(InitializeValueItem());

            Code = new List<CodeModel>();
            Code.Add(InitializeCode());

            Team = new List<TeamModel>();
            Team.Add(InitializeTeam());

            User = new List<UserModel>();
            User.Add(InitializeUser());

            Technician = new List<TechnicianModel>();
            Technician.Add(InitializeTechnician());

            TeamTechnician = new List<TeamTechnicianModel>();
            TeamTechnician.Add(InitializeTeamTechnician());

            Craft = new List<CraftModel>();
            Craft.Add(InitializeCraft());

            UnitOfMeasure = new List<UnitOfMeasureModel>();
            UnitOfMeasure.Add(InitializeUnitOfMeasure());

            MeterGroup = new List<MeterGroupModel>();
            MeterGroup.Add(InitializeMeterGroup());

            Meter = new List<MeterModel>();
            Meter.Add(InitializeMeter());

            MeterLineItem = new List<MeterLineItemModel>();
            MeterLineItem.Add(InitializeMeterLineItem());

            Point = new List<PointModel>();
            Point.Add(InitializePoint());

            PointMeterLineItem = new List<PointMeterLineItemModel>();
            PointMeterLineItem.Add(InitializePointMeterLineItem());

            Reading = new List<ReadingModel>();
            Reading.Add(InitializeReading());

            Comment = new List<CommentModel>();
            Comment.Add(InitializeComment());

            Attachment = new List<AttachmentModel>();
            Attachment.Add(InitializeAttachment());
        }

        private WorkOrderModel InitializeWorkOrder()
        {
            var result = new WorkOrderModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                SyncId = "",
                Number = "",
                Description = "",
                Priority = 0,
                AssignmentId = 0,
                AssignmentType = "",
                AssignmentAmount = 0,
                CreatedUserId = 0,
                HierarchyIdPath = "",
                HierarchyNamePath = "",
                ParentId = 0,
                ParentNumber = "",
                SiteId = 0,
                AssetId = 0,
                LocationId = 0,
                WorkCategoryId = 0,
                WorkTypeId = 0,
                FailureGroupId = 0,
                ServiceRequestId = 0,
                ServiceRequestNumber = "",
                PreventiveMaintenanceId = 0,
                PreventiveMaintenanceNumber = "",
                RequestorName = "",
                RequestorEmail = "",
                RequestorPhone = "",
                RequestedDateTime = DateTime.UtcNow,
                SupervisorId = 0,
                TaskGroupId = 0,
                ExpectedStartDateTime = DateTime.UtcNow,
                DueDateTime = DateTime.UtcNow,
                ActualStartDateTime = DateTime.UtcNow,
                ActualEndDateTime = DateTime.UtcNow,
                ActualFailureGroupId = 0,
                ActualProblemId = 0,
                ActualCauseId = 0,
                ResolutionId = 0,
                ResolutionNotes = ""
            };

            return result;
        }

        private WorkOrderLaborModel InitializeWorkOrderLabor()
        {
            var result = new WorkOrderLaborModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                SyncId = "",
                WorkOrderId = 0,
                TeamId = 0,
                TechnicianId = 0,
                CraftId = 0,
                PlanHours = 0,
                StandardRate = 0,
                OTRate = 0,
                PlanTotal = 0,
                ActualNormalHours = 0,
                ActualOTHours = 0,
                ActualTotal = 0
            };

            return result;
        }

        private WorkOrderTaskModel InitializeWorkOrderTask()
        {
            var result = new WorkOrderTaskModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                SyncId = "",
                WorkOrderId = 0,
                Sequence = 0,
                Description = "",
                AssignedUserId = 0,
                CompletedUserId = 0,
                CompletedDate = DateTime.UtcNow,
                HoursSpent = 0,
                Result = 0,
                CompletionNotes = ""
            };

            return result;
        }

        private WorkOrderItemModel InitializeWorkOrderItem()
        {
            var result = new WorkOrderItemModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                SyncId = "",
                WorkOrderId = 0,
                StoreId = 0,
                StoreName = "",
                ItemId = 0,
                ItemName = "",
                ItemCategoryText = "",
                StoreLocatorId = 0,
                StoreLocatorName = "",
                UnitPrice = 0,
                PlanQuantity = 0,
                PlanTotal = 0,
                ActualQuantity = 0,
                ActualTotal = 0,
                PlanToolHours = 0,
                ToolRate = 0,
                ActualToolHours = 0,
            };

            return result;
        }

        private WorkOrderServiceItemModel InitializeWorkOrderServiceItem()
        {
            var result = new WorkOrderServiceItemModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                SyncId = "",
                WorkOrderId = 0,
                ServiceItemId = 0,
                ServiceItemName = "",
                Description = "",
                PlanUnitPrice = 0,
                PlanQuantity = 0,
                PlanTotal = 0,
                ActualUnitPrice = 0,
                ActualQuantity = 0,
                ActualTotal = 0
            };

            return result;
        }

        private WorkOrderMiscCostModel InitializeWorkOrderMiscCost()
        {
            var result = new WorkOrderMiscCostModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                SyncId = "",
                WorkOrderId = 0,
                Sequence = 0,
                Description = "",
                PlanUnitPrice = 0,
                PlanQuantity = 0,
                PlanTotal = 0,
                ActualUnitPrice = 0,
                ActualQuantity = 0,
                ActualTotal = 0
            };

            return result;
        }

        private AssignmentModel InitializeAssignment()
        {
            var result = new AssignmentModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                EntityId = 0,
                EntityType = "",
                Number = "",
                Description = "",
                Priority = 0,
                AssignmentType = "",
                AssignmentAmount = 0,
                Comment = "",
                AvailableActions = "",
                TriggeredAction = "",
                ExpectedStartDateTime = DateTime.UtcNow,
                DueDateTime = DateTime.UtcNow,
                WorkflowInstanceId = "",
                WorkflowVersion = 0
            };

            return result;
        }

        private AssignmentUserModel InitializeAssignmentUser()
        {
            var result = new AssignmentUserModel
            {
                AssignmentId = 0,
                UserId = 0
            };

            return result;
        }

        private SiteModel InitializeSite()
        {
            var result = new SiteModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                Description = "",
                OrganizationId = 0,
                OrganizationName = ""
            };

            return result;
        }

        private AssetModel InitializeAsset()
        {
            var result = new AssetModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                HierarchyIdPath = "",
                HierarchyNamePath = "",
                ParentId = 0,
                SiteId = 0,
                AssetTypeId = 0,
                AssetStatusId = 0,
                LocationId = 0,
                SerialNumber = "",
                ManufacturerId = 0,
                ManufacturerName = "",
                VendorId = 0,
                VendorName = "",
                InstallationDate = DateTime.UtcNow,
                InstallationCost = 0,
                PurchasePrice = 0,
                Period = 0,
                WarrantyStartDate = DateTime.UtcNow,
                WarrantyEndDate = DateTime.UtcNow
            };

            return result;
        }

        private LocationModel InitializeLocation()
        {
            var result = new LocationModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                HierarchyIdPath = "",
                HierarchyNamePath = "",
                ParentId = 0,
                SiteId = 0,
                LocationTypeId = 0,
                LocationStatusId = 0,
                AddressId = 0,
                AddressCountry = "",
                AddressStateProvince = "",
                AddressCity = "",
                AddressAddress1 = "",
                AddressAddress2 = "",
                AddressZipPostalCode = "",
                AddressPhoneNumber = "",
                AddressFaxNumber = "",
                AddressEmail = ""
            };

            return result;
        }

        private ValueItemCategoryModel InitializeValueItemCategory()
        {
            var result = new ValueItemCategoryModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
            };

            return result;
        }

        private ValueItemModel InitializeValueItem()
        {
            var result = new ValueItemModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                ValueItemCategoryId = 0
            };

            return result;
        }

        private CodeModel InitializeCode()
        {
            var result = new CodeModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                Description = "",
                HierarchyIdPath = "",
                HierarchyNamePath = "",
                ParentId = 0,
                CodeType = ""
            };

            return result;
        }

        private TeamModel InitializeTeam()
        {
            var result = new TeamModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                Description = "",
                SiteId = 0
            };

            return result;
        }

        private UserModel InitializeUser()
        {
            var result = new UserModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                LoginName = "",
                LoginPassword = "",
                PublicKey = "",
                SecretKey = "",
                Email = "",
                Phone = "",
                TimeZoneId = "",
                LanguageId = 0,
                LanguageName = "",
                SupervisorId = 0,
                SupervisorName = "",
                DefaultSiteId = 0,
                CurrencySymbol = ""
            };

            return result;
        }

        private TechnicianModel InitializeTechnician()
        {
            var result = new TechnicianModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                UserId = 0,
                CalendarId = 0,
                CalendarName = "",
                ShiftId = 0,
                ShiftName = "",
                CraftId = 0
            };

            return result;
        }

        private TeamTechnicianModel InitializeTeamTechnician()
        {
            var result = new TeamTechnicianModel
            {
                TeamId = 0,
                TechnicianId = 0
            };

            return result;
        }

        private CraftModel InitializeCraft()
        {
            var result = new CraftModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                Description = "",
                StandardRate = 0,
                OvertimeRate = 0
            };

            return result;
        }

        private UnitOfMeasureModel InitializeUnitOfMeasure()
        {
            var result = new UnitOfMeasureModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                Abbreviation = "",
                Description = ""
            };

            return result;
        }

        private MeterGroupModel InitializeMeterGroup()
        {
            var result = new MeterGroupModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                Description = ""
            };

            return result;
        }

        private MeterModel InitializeMeter()
        {
            var result = new MeterModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                Description = "",
                MeterTypeId = 0,
                UnitOfMeasureId = 0
            };

            return result;
        }

        private MeterLineItemModel InitializeMeterLineItem()
        {
            var result = new MeterLineItemModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                DisplayOrder = 0,
                MeterGroupId = 0,
                MeterId = 0
            };

            return result;
        }

        private PointModel InitializePoint()
        {
            var result = new PointModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                LocationId = 0,
                AssetId = 0,
                MeterGroupId = 0
            };

            return result;
        }

        private PointMeterLineItemModel InitializePointMeterLineItem()
        {
            var result = new PointMeterLineItemModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                DisplayOrder = 0,
                PointId = 0,
                MeterId = 0,
                LastReadingValue = 0,
                LastDateOfReading = DateTime.UtcNow,
                LastReadingUser = ""
            };

            return result;
        }

        private ReadingModel InitializeReading()
        {
            var result = new ReadingModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                PointMeterLineItemId = 0,
                ReadingValue = 0,
                DateOfReading = DateTime.UtcNow,
                ReadingSource = 0,
                WorkOrderId = 0
            };

            return result;
        }

        private CommentModel InitializeComment()
        {
            var result = new CommentModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                EntityId = 0,
                EntityType = "",
                Message = ""
            };

            return result;
        }

        private AttachmentModel InitializeAttachment()
        {
            var result = new AttachmentModel
            {
                Id = 0,
                Name = "",
                CreatedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                CreatedUser = "",
                ModifiedUser = "",
                EntityId = 0,
                EntityType = "",
                ImageBase64String = ""
            };

            return result;
        }
    }
}