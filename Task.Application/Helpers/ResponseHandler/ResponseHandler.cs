using Azure;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tsk.Application.Helpers.ResponseHandler
{
    public static class ResponseHandler
    {
        public static Respons<T> Updated<T>(T entity)
        {
            return new Respons<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Updated Successfully",
                Data = entity
            };
        }
        public static Respons<T> Deleted<T>()
        {
            return new Respons<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Deleted Successfully"
            };
        }
        public static Respons<T> Success<T>(string message = "succeeded process")
        {
            return new Respons<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = message,
            };
        }
        public static Respons<T> Success<T>(T entity, object Meta = null)
        {
            return new Respons<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "succeeded process",
                Meta = Meta
            };
        }
        public static Respons<T> Unauthorized<T>()
        {
            return new Respons<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = "UnAuthorized"
            };
        }
        public static Respons<T> BadRequest<T>(string Message = null)
        {
            return new Respons<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message == null ? "Bad Request" : Message
            };
        }

        public static Respons<T> NotFound<T>(string message = null)
        {
            return new Respons<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? "Not Found" : message
            };
        }

        public static Respons<T> Created<T>(T entity, object Meta = null)
        {
            return new Respons<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = "Entity created",
                Meta = Meta
            };
        }
        public static IActionResult CreateResponse<T>(this ControllerBase controllerBase, Respons<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode

            };
        }
    }
}
