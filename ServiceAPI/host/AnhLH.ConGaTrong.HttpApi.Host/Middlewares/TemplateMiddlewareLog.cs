using System;

namespace AnhLH.ConGaTrong.Middlewares;

public class TemplateMiddlewareLog
{
    public DateTime StartDate { get; set; }
    public string Host { get; set; }
    public string Path { get; set; }
    public string QueryString { get; set; }
    public string Method { get; set; }
    public string BodyRequest { get; set; }
    public int? StatusCode { get; set; }
    public string BodyResponse { get; set; }
    public double? ExecutionTime { get; set; }
    public string FullPath { get; set; }
}