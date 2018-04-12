using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MoFang.MobileSite.Core.Model;
using MoFang.MobileSite.Core.Model.Config;
using MoFang.MobileSite.Domain.Entity;
using Microsoft.Extensions.Options;

namespace MoFang.MobileSite.Core.Service
{
    /// <summary>
    /// 首页动态逻辑
    /// </summary>
    public class TimeLineService :ServiceBase
    {
        private IMapper mapper;
        public TimeLineService(IServiceProvider serviceProvider)
            : base(serviceProvider)

        {
            this.mapper = serviceProvider.GetService<IMapper>();
        }

        ///// <summary>
        ///// 提交动态
        ///// </summary>
        ///// <param name="timeLineModel"></param>
        ///// <returns></returns>
        //public async Task<Result> PostTimeLine(TimeLineModel timeLineModel,long userId)
        //{
        //    using (var uw = this.CreateUnitOfWork())
        //    {
        //        using (var tran = uw.BeginTransaction())
        //        {
        //            var timeLineEntity = mapper.Map<TimeLineModel, TimeLine>(timeLineModel);
        //            timeLineEntity.CreateDate = DateTime.Now;
        //            await uw.InsertAsync(timeLineEntity);
        //            var timeLineId = timeLineEntity.ID;
        //            TimeLineImage timeLineImage = new TimeLineImage();
        //            if (timeLineModel.Images.Count > 0)
        //            {
        //                timeLineImage.ImagePath = timeLineModel.Images[0].ImagePath;
        //                timeLineImage.TimeLineID = timeLineId;
        //                timeLineImage.UserId = userId;
        //                timeLineImage.CreateDate=DateTime.Now;
        //            }
        //            await uw.InsertAsync(timeLineImage);
        //            tran.Commit();
        //            return Result.SuccessResult(timeLineEntity.ID);
        //        }
        //    }
        //}

        ///// <summary>
        ///// 获取动态列表
        ///// </summary>
        ///// <param name="userId"></param>
        ///// <param name="imagePathConfig"></param>
        ///// <returns></returns>
        //public async Task<Result> GetTimeLineList(long userId)
        //{
        //    using (var uw = this.CreateUnitOfWork())
        //    {
        //        var timeLineEntityList = await uw.QueryAsync<TimeLine>(x => x.UserID == userId);
        //        var timeLineModelList = mapper.Map<List<TimeLine>, List<TimeLineModel>>(timeLineEntityList);
        //        foreach (var item in timeLineModelList)
        //        {
        //            var timeLineImageEntityList = await uw.QueryAsync<TimeLineImage>(x=>x.TimeLineID==item.ID);
        //            foreach (var itemtli in timeLineImageEntityList)
        //            {
        //                itemtli.ImagePath = QiniuConfig.Value.QiniuBucketPath + itemtli.ImagePath;
        //            }
        //            item.Images = mapper.Map<List<TimeLineImage>, List<TimeLineImageModel>>(timeLineImageEntityList);
        //        }
        //        return Result.SuccessResult(timeLineModelList);
        //    }
        //}
    }
}
