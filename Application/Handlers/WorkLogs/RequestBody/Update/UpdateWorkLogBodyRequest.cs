﻿using Application.Models.Abstracts;
using Application.Models.Response.WorkLog;
using MediatR;

namespace Application.Handlers.WorkLogs.RequestBody.Update
{
    public class UpdateWorkLogBodyRequest : IRequest<ResponseBase<UpdateWorkLogResponseItem>>
    {
        public long Id { get; set; }
        public long ActivityId { get; set; }
        public long EmployeeId { get; set; }
        public DateTime EntryDateTime { get; set; }
        public DateTime? ExitDateTime { get; set; }
        public string? Break { get; set; }
        public float WorkHours { get; set; }
        public byte DayType { get; set; }
        public string? Description { get; set; }
        public byte Status { get; set; }
        public string? Transport { get; set; }
        public string? Expenses { get; set; }
        public string? ValidationResponsible { get; set; }
        public DateTime InsertUpdateDate { get; set; }
    }
}