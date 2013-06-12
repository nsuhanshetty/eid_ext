using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eid
{
	class User
	{
        static int mUserId;
        public static int UserId
        {
            get
            {
                return mUserId;
            }
            set
            {
                mUserId = value;
            }
        }
	}

    

}
