using System.ComponentModel;

namespace Xyh.Portal
{
    public class PortalAppConsts
    {

        /// <summary>
        /// 通讯录
        /// </summary>
        public const string TongXunLu = "通讯录";
        /// <summary>
        /// HR自助
        /// </summary>
        public const string HrHelp = "HR自助";

        /// <summary>
        /// 消息推送类型
        /// </summary>
        public enum MessagePushType
        {
            /// <summary>
            /// 公告
            /// </summary>
            [Description("公告")]
            Notice = 7,
            /// <summary>
            /// 协同,表单
            /// </summary>
            [Description("协同")]
            Collaboration = 1,
            /// <summary>
            /// 会议
            /// </summary>
            [Description("会议")]
            Meeting = 6,
            /// <summary>
            /// 新闻
            /// </summary>
            [Description("新闻")]
            News = 8,
            /// <summary>
            /// 讨论
            /// </summary>
            [Description("讨论")]
            Discuss = 9,
            /// <summary>
            /// 调查
            /// </summary>
            [Description("调查")]
            Survey = 10,
            /// <summary>
            /// 日程事件
            /// </summary>
            [Description("日程事件")]
            ScheduleEvent = 11,
            /// <summary>
            /// 知识社区
            /// </summary>
            [Description("知识社区")]
            Document = 3,
            /// <summary>
            /// 公文
            /// </summary>
            [Description("公文")]
            OfficialDocument = 4,
            ///// <summary>
            ///// 表单
            ///// </summary>
            //[Description("msg_bd.png")]
            //Form = 1,
            /// <summary>
            /// 工作计划
            /// </summary>
            [Description("工作计划")]
            WorkPlan = 5,
            /// <summary>
            /// 任务
            /// </summary>
            [Description("任务")]
            Task = 30,
            /// <summary>
            /// 行为绩效
            /// </summary>
            [Description("行为绩效")]
            Performance = 42,
            /// <summary>
            /// 签到
            /// </summary>
            [Description("签到")]
            SignIn = 36,
            /// <summary>
            /// 培训助手
            /// </summary>
            [Description("培训助手")]
            Training = 102,
            /// <summary>
            /// IT服务
            /// </summary>
            [Description("IT服务")]
            ITService = 101,
            /// <summary>
            /// 系统消息
            /// </summary>
            [Description("系统消息")]
            SystemMessage = 200,
            /// <summary>
            /// 考勤助手
            /// </summary>
            [Description("考勤助手")]
            AbnormalAttendance = 103,
            /// <summary>
            /// 呼叫台
            /// </summary>
            [Description("呼叫台")]
            CallCenter = 104,
            /// <summary>
            /// 工作助理
            /// </summary>
            [Description("工作助理")]
            WorkAgent = 203,
            /// <summary>
            /// PM呼叫台
            /// </summary>
            [Description("PM呼叫台")]
            PMCallCenter = 105,
            /// <summary>
            /// 政府事务
            /// </summary>
            [Description("政府事务")]
            GovernmentAffairs = 106,
            /// <summary>
            /// 银企助手
            /// </summary>
            [Description("银企助手")]
            H2HAgent = 204,
            /// <summary>
            /// HR服务台
            /// </summary>
            [Description("HR服务台")]
            HRService = 107,
            /// <summary>
            /// 恭和会
            /// </summary>
            [Description("恭和会")]
            GHH = 108,
            /// <summary>
            /// 明源ERP待办消息
            /// </summary>
            [Description("明源ERP待办消息")]
            POMPending = 300
        }

        /// <summary>
        /// 报表类型
        /// </summary>
        public enum ReportType
        {
            [Description("入住率")]
            OccupancyRate = 1

        }

        /// <summary>
        /// 报表类型
        /// </summary>
        public enum ReportState
        {
            [Description("待审核")]
            PendingReview = 0,
            [Description("已审核")]
            Audited = 1
        }

        /// <summary>
        /// 附件类型
        /// </summary>
        public enum AttachmentType
        {
            [Description("临时文件")]
            Template = 0,
            [Description("发布文件")]
            Release = 1
        }

        /// <summary>
        /// App类型
        /// </summary>
        public enum TerminalType
        {
            Web = 0,
            Android = 1,
            Ios = 2
        }
        /// <summary>
        /// 客户端类型
        /// </summary>
        public enum EClientType
        {
            Mobile = 1,
            PC = 2,
            Pad = 3
        }
        /// <summary>
        /// 功能模块
        /// </summary>
        public enum ModuleType
        {
            Default = 0,
            Address = 1
        }
    }

    public class RongYunStaffType
    {
        /// <summary>
        /// 员工
        /// </summary>
        public const string Staff = "员工";
        /// <summary>
        /// 老人
        /// </summary>
        public const string Customer = "老人";
    }
}
