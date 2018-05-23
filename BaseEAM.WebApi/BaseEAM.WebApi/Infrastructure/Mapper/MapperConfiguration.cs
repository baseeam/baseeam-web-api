/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using AutoMapper;
using BaseEAM.Core.Domain;
using BaseEAM.Core.Infrastructure.Mapper;
using BaseEAM.WebApi.Models;
using System;

namespace BaseEAM.WebApi.Infrastructure.Mapper
{
    public class MapperConfiguration : IMapperConfiguration
    {
        /// <summary>
        /// Get configuration
        /// </summary>
        /// <returns>Mapper configuration action</returns>
        public Action<IMapperConfigurationExpression> GetConfiguration()
        {
            Action<IMapperConfigurationExpression> action = cfg =>
            {
                //Comment
                cfg.CreateMap<Comment, CommentModel>();
                cfg.CreateMap<CommentModel, Comment>();

                //Reading
                cfg.CreateMap<Reading, ReadingModel>();
                cfg.CreateMap<ReadingModel, Reading>();

                //PointMeterLineItem
                cfg.CreateMap<PointMeterLineItem, PointMeterLineItemModel>();
                cfg.CreateMap<PointMeterLineItemModel, PointMeterLineItem>();

                //Point
                cfg.CreateMap<Point, PointModel>();
                cfg.CreateMap<PointModel, Point>();

                //MeterLineItem
                cfg.CreateMap<MeterLineItem, MeterLineItemModel>();
                cfg.CreateMap<MeterLineItemModel, MeterLineItem>();

                //MeterGroup
                cfg.CreateMap<MeterGroup, MeterGroupModel>();
                cfg.CreateMap<MeterGroupModel, MeterGroup>();

                //Meter
                cfg.CreateMap<Meter, MeterModel>();
                cfg.CreateMap<MeterModel, Meter>();

                //UnitOfMeasure
                cfg.CreateMap<UnitOfMeasure, UnitOfMeasureModel>();
                cfg.CreateMap<UnitOfMeasureModel, UnitOfMeasure>();

                //WorkOrderMiscCost
                cfg.CreateMap<WorkOrderMiscCost, WorkOrderMiscCostModel>();
                cfg.CreateMap<WorkOrderMiscCostModel, WorkOrderMiscCost>();

                //WorkOrderServiceItem
                cfg.CreateMap<WorkOrderServiceItem, WorkOrderServiceItemModel>();
                cfg.CreateMap<WorkOrderServiceItemModel, WorkOrderServiceItem>();

                //WorkOrderItem
                cfg.CreateMap<WorkOrderItem, WorkOrderItemModel>()
                    .ForMember(dest => dest.ItemCategoryText, opt => opt.MapFrom(src => src.Item == null ? "" : ((ItemCategory)src.Item.ItemCategory).ToString()));
                cfg.CreateMap<WorkOrderItemModel, WorkOrderItem>();

                //WorkOrderTask
                cfg.CreateMap<WorkOrderTask, WorkOrderTaskModel>();
                cfg.CreateMap<WorkOrderTaskModel, WorkOrderTask>();

                //WorkOrderLabor
                cfg.CreateMap<WorkOrderLabor, WorkOrderLaborModel>();
                cfg.CreateMap<WorkOrderLaborModel, WorkOrderLabor>();

                //Craft
                cfg.CreateMap<Craft, CraftModel>();
                cfg.CreateMap<CraftModel, Craft>();

                //Technician
                cfg.CreateMap<Technician, TechnicianModel>();
                cfg.CreateMap<TechnicianModel, Technician>();

                //Team
                cfg.CreateMap<Team, TeamModel>();
                cfg.CreateMap<TeamModel, Team>();

                //User
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();

                //WorkOrder
                cfg.CreateMap<WorkOrder, WorkOrderModel>();
                cfg.CreateMap<WorkOrderModel, WorkOrder>();

                //Assignment
                cfg.CreateMap<Assignment, AssignmentModel>();
                cfg.CreateMap<AssignmentModel, Assignment>();

                //Site
                cfg.CreateMap<Site, SiteModel>();
                cfg.CreateMap<SiteModel, Site>();

                //Asset
                cfg.CreateMap<Asset, AssetModel>();
                cfg.CreateMap<AssetModel, Asset>();

                //Location
                cfg.CreateMap<Location, LocationModel>();
                cfg.CreateMap<LocationModel, Location>();

                //ValueItemCategory
                cfg.CreateMap<ValueItemCategory, ValueItemCategoryModel>();
                cfg.CreateMap<ValueItemCategoryModel, ValueItemCategory>();

                //ValueItem
                cfg.CreateMap<ValueItem, ValueItemModel>();
                cfg.CreateMap<ValueItemModel, ValueItem>();

                //Code
                cfg.CreateMap<Code, CodeModel>();
                cfg.CreateMap<CodeModel, Code>();
            };

            return action;
        }

        /// <summary>
        /// Order of this mapper implementation
        /// </summary>
        public int Order
        {
            get { return 0; }
        }
    }
}