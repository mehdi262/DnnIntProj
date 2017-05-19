using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnnInterProj.Biz
{
    public static class ReturnCodeReference
    {
        public const int Created_SuccessFully = 201;
        public const int Updated_SuccessFully = 211;
        public const int Deleted_SuccessFully = 221;


        public const int NotCreated_EmailFormatProblem = 401;
        public const int NotCreated_UsernameExist = 402;
        public const int NotCreated_UnknownReason = 409;

        public const int NotUpdated_EmailDormatProblem = 411;
        public const int NotUpdated_UsernameExist = 412;
        public const int NotUpdated_IdNotExist = 413;
        public const int NotUpdated_UnknownReason = 419;

        public const int NotDeleted_IdNotExist = 421;
        public const int NotDeleted_UnknownReason = 429;

    }
}
