using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HXF.WebServices.Server
{
    public class ServiceResult
    {
        public bool Successful;
        public string ErrorMessage;
        public Object Value;

        public static ServiceResult CreateSuccessfulResult(object value)
        {
            ServiceResult r = new ServiceResult();
            r.Successful = true;
            r.ErrorMessage = null;
            r.Value = value;
            return r;
        }

        public static ServiceResult CreateSuccessfulResult()
        {
            return ServiceResult.CreateSuccessfulResult(null);
        }

        public static ServiceResult CreateFailResult(Exception exception)
        {
            ServiceResult r = new ServiceResult();
            r.Successful = false;
            r.ErrorMessage = exception.Message;
            r.Value = null;
            return r;
        }

        public static ServiceResult CreateFailResult(string errorMessage)
        {
            ServiceResult r = new ServiceResult();
            r.Successful = false;
            r.ErrorMessage = errorMessage;
            r.Value = null;
            return r;
        }


    }
}
