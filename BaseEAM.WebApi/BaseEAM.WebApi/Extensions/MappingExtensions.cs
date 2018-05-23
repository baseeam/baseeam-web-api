/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using Autofac;
using BaseEAM.Core.Domain;
using BaseEAM.Core.Infrastructure.Mapper;
using BaseEAM.Core.Reflection;
using BaseEAM.Core.Timing.Utils;
using BaseEAM.Core.WebApi;
using BaseEAM.Services;
using BaseEAM.WebApi.Models;
using System;

namespace BaseEAM.WebApi.Extensions
{
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            //If we are mapping from Entity to Model
            //then we will convert all DateTime values from UTC to User timezone.
            //We need to mark complex properties with attribute ComplexTypeAttribute
            var destination = AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
            var dateTimeHelper = WebApiEngineContext.Current.Resolve<IDateTimeHelper>();
            var dateTimePropertyInfos = DateTimePropertyInfoHelper.GetDatePropertyInfos(typeof(TDestination));
            dateTimePropertyInfos.DateTimePropertyInfos.ForEach(property =>
            {
                var dateTime = (DateTime?)property.GetValue(destination);
                if (dateTime.HasValue)
                {
                    property.SetValue(destination, dateTimeHelper.ConvertToUserTime(dateTime.Value, DateTimeKind.Utc));
                }
            });

            dateTimePropertyInfos.ComplexTypePropertyPaths.ForEach(propertPath =>
            {
                var dateTime = (DateTime?)ReflectionHelper.GetValueByPath(destination, typeof(TDestination), propertPath);
                if (dateTime.HasValue)
                {
                    ReflectionHelper.SetValueByPath(destination, typeof(TDestination), propertPath, dateTimeHelper.ConvertToUserTime(dateTime.Value, DateTimeKind.Utc));
                }
            });
            return destination;
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        #region Comment

        public static CommentModel ToModel(this Comment entity)
        {
            return entity.MapTo<Comment, CommentModel>();
        }

        public static Comment ToEntity(this CommentModel model)
        {
            return model.MapTo<CommentModel, Comment>();
        }

        public static Comment ToEntity(this CommentModel model, Comment destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region Reading

        public static ReadingModel ToModel(this Reading entity)
        {
            return entity.MapTo<Reading, ReadingModel>();
        }

        public static Reading ToEntity(this ReadingModel model)
        {
            return model.MapTo<ReadingModel, Reading>();
        }

        public static Reading ToEntity(this ReadingModel model, Reading destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region PointMeterLineItem

        public static PointMeterLineItemModel ToModel(this PointMeterLineItem entity)
        {
            return entity.MapTo<PointMeterLineItem, PointMeterLineItemModel>();
        }

        public static PointMeterLineItem ToEntity(this PointMeterLineItemModel model)
        {
            return model.MapTo<PointMeterLineItemModel, PointMeterLineItem>();
        }

        public static PointMeterLineItem ToEntity(this PointMeterLineItemModel model, PointMeterLineItem destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region Point

        public static PointModel ToModel(this Point entity)
        {
            return entity.MapTo<Point, PointModel>();
        }

        public static Point ToEntity(this PointModel model)
        {
            return model.MapTo<PointModel, Point>();
        }

        public static Point ToEntity(this PointModel model, Point destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region MeterLineItem

        public static MeterLineItemModel ToModel(this MeterLineItem entity)
        {
            return entity.MapTo<MeterLineItem, MeterLineItemModel>();
        }

        public static MeterLineItem ToEntity(this MeterLineItemModel model)
        {
            return model.MapTo<MeterLineItemModel, MeterLineItem>();
        }

        public static MeterLineItem ToEntity(this MeterLineItemModel model, MeterLineItem destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region MeterGroup

        public static MeterGroupModel ToModel(this MeterGroup entity)
        {
            return entity.MapTo<MeterGroup, MeterGroupModel>();
        }

        public static MeterGroup ToEntity(this MeterGroupModel model)
        {
            return model.MapTo<MeterGroupModel, MeterGroup>();
        }

        public static MeterGroup ToEntity(this MeterGroupModel model, MeterGroup destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region Meter

        public static MeterModel ToModel(this Meter entity)
        {
            return entity.MapTo<Meter, MeterModel>();
        }

        public static Meter ToEntity(this MeterModel model)
        {
            return model.MapTo<MeterModel, Meter>();
        }

        public static Meter ToEntity(this MeterModel model, Meter destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region UnitOfMeasure

        public static UnitOfMeasureModel ToModel(this UnitOfMeasure entity)
        {
            return entity.MapTo<UnitOfMeasure, UnitOfMeasureModel>();
        }

        public static UnitOfMeasure ToEntity(this UnitOfMeasureModel model)
        {
            return model.MapTo<UnitOfMeasureModel, UnitOfMeasure>();
        }

        public static UnitOfMeasure ToEntity(this UnitOfMeasureModel model, UnitOfMeasure destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region WorkOrderMiscCost

        public static WorkOrderMiscCostModel ToModel(this WorkOrderMiscCost entity)
        {
            return entity.MapTo<WorkOrderMiscCost, WorkOrderMiscCostModel>();
        }

        public static WorkOrderMiscCost ToEntity(this WorkOrderMiscCostModel model)
        {
            return model.MapTo<WorkOrderMiscCostModel, WorkOrderMiscCost>();
        }

        public static WorkOrderMiscCost ToEntity(this WorkOrderMiscCostModel model, WorkOrderMiscCost destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region WorkOrderServiceItem

        public static WorkOrderServiceItemModel ToModel(this WorkOrderServiceItem entity)
        {
            return entity.MapTo<WorkOrderServiceItem, WorkOrderServiceItemModel>();
        }

        public static WorkOrderServiceItem ToEntity(this WorkOrderServiceItemModel model)
        {
            return model.MapTo<WorkOrderServiceItemModel, WorkOrderServiceItem>();
        }

        public static WorkOrderServiceItem ToEntity(this WorkOrderServiceItemModel model, WorkOrderServiceItem destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region WorkOrderItem

        public static WorkOrderItemModel ToModel(this WorkOrderItem entity)
        {
            return entity.MapTo<WorkOrderItem, WorkOrderItemModel>();
        }

        public static WorkOrderItem ToEntity(this WorkOrderItemModel model)
        {
            return model.MapTo<WorkOrderItemModel, WorkOrderItem>();
        }

        public static WorkOrderItem ToEntity(this WorkOrderItemModel model, WorkOrderItem destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region WorkOrderTask

        public static WorkOrderTaskModel ToModel(this WorkOrderTask entity)
        {
            return entity.MapTo<WorkOrderTask, WorkOrderTaskModel>();
        }

        public static WorkOrderTask ToEntity(this WorkOrderTaskModel model)
        {
            return model.MapTo<WorkOrderTaskModel, WorkOrderTask>();
        }

        public static WorkOrderTask ToEntity(this WorkOrderTaskModel model, WorkOrderTask destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region WorkOrderLabor

        public static WorkOrderLaborModel ToModel(this WorkOrderLabor entity)
        {
            return entity.MapTo<WorkOrderLabor, WorkOrderLaborModel>();
        }

        public static WorkOrderLabor ToEntity(this WorkOrderLaborModel model)
        {
            return model.MapTo<WorkOrderLaborModel, WorkOrderLabor>();
        }

        public static WorkOrderLabor ToEntity(this WorkOrderLaborModel model, WorkOrderLabor destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region Craft

        public static CraftModel ToModel(this Craft entity)
        {
            return entity.MapTo<Craft, CraftModel>();
        }

        public static Craft ToEntity(this CraftModel model)
        {
            return model.MapTo<CraftModel, Craft>();
        }

        public static Craft ToEntity(this CraftModel model, Craft destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region Technician

        public static TechnicianModel ToModel(this Technician entity)
        {
            return entity.MapTo<Technician, TechnicianModel>();
        }

        public static Technician ToEntity(this TechnicianModel model)
        {
            return model.MapTo<TechnicianModel, Technician>();
        }

        public static Technician ToEntity(this TechnicianModel model, Technician destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region Team

        public static TeamModel ToModel(this Team entity)
        {
            return entity.MapTo<Team, TeamModel>();
        }

        public static Team ToEntity(this TeamModel model)
        {
            return model.MapTo<TeamModel, Team>();
        }

        public static Team ToEntity(this TeamModel model, Team destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region User

        public static UserModel ToModel(this User entity)
        {
            return entity.MapTo<User, UserModel>();
        }

        public static User ToEntity(this UserModel model)
        {
            return model.MapTo<UserModel, User>();
        }

        public static User ToEntity(this UserModel model, User destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region WorkOrder

        public static WorkOrderModel ToModel(this WorkOrder entity)
        {
            return entity.MapTo<WorkOrder, WorkOrderModel>();
        }

        public static WorkOrder ToEntity(this WorkOrderModel model)
        {
            return model.MapTo<WorkOrderModel, WorkOrder>();
        }

        public static WorkOrder ToEntity(this WorkOrderModel model, WorkOrder destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region Assignment

        public static AssignmentModel ToModel(this Assignment entity)
        {
            return entity.MapTo<Assignment, AssignmentModel>();
        }

        public static Assignment ToEntity(this AssignmentModel model)
        {
            return model.MapTo<AssignmentModel, Assignment>();
        }

        public static Assignment ToEntity(this AssignmentModel model, Assignment destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region Site

        public static SiteModel ToModel(this Site entity)
        {
            return entity.MapTo<Site, SiteModel>();
        }

        public static Site ToEntity(this SiteModel model)
        {
            return model.MapTo<SiteModel, Site>();
        }

        public static Site ToEntity(this SiteModel model, Site destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region Asset

        public static AssetModel ToModel(this Asset entity)
        {
            return entity.MapTo<Asset, AssetModel>();
        }

        public static Asset ToEntity(this AssetModel model)
        {
            return model.MapTo<AssetModel, Asset>();
        }

        public static Asset ToEntity(this AssetModel model, Asset destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region Location

        public static LocationModel ToModel(this Location entity)
        {
            return entity.MapTo<Location, LocationModel>();
        }

        public static Location ToEntity(this LocationModel model)
        {
            return model.MapTo<LocationModel, Location>();
        }

        public static Location ToEntity(this LocationModel model, Location destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region ValueItemCategory

        public static ValueItemCategoryModel ToModel(this ValueItemCategory entity)
        {
            return entity.MapTo<ValueItemCategory, ValueItemCategoryModel>();
        }

        public static ValueItemCategory ToEntity(this ValueItemCategoryModel model)
        {
            return model.MapTo<ValueItemCategoryModel, ValueItemCategory>();
        }

        public static ValueItemCategory ToEntity(this ValueItemCategoryModel model, ValueItemCategory destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region ValueItem

        public static ValueItemModel ToModel(this ValueItem entity)
        {
            return entity.MapTo<ValueItem, ValueItemModel>();
        }

        public static ValueItem ToEntity(this ValueItemModel model)
        {
            return model.MapTo<ValueItemModel, ValueItem>();
        }

        public static ValueItem ToEntity(this ValueItemModel model, ValueItem destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region Code

        public static CodeModel ToModel(this Code entity)
        {
            return entity.MapTo<Code, CodeModel>();
        }

        public static Code ToEntity(this CodeModel model)
        {
            return model.MapTo<CodeModel, Code>();
        }

        public static Code ToEntity(this CodeModel model, Code destination)
        {
            return model.MapTo(destination);
        }

        #endregion
    }
}