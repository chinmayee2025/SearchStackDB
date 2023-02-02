using SearchStackDatabase.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace SearchStackDatabase.IService
{
    public interface INotiService
    {
        List<Noti> GetNotifications(int nToUserId, bool bIsGetOnlyUnread);

    }
}
