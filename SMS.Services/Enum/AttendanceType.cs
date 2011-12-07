using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Services.Enum
{
    public enum AttendanceType
    {
        /// <summary>
        /// 未到
        /// </summary>
        UnArrive,

        /// <summary>
        /// 到达
        /// </summary>
        Arrive,

        /// <summary>
        /// 迟到
        /// </summary>
        Late,

        /// <summary>
        /// 请假
        /// </summary>
        AskOff,

    }
}
