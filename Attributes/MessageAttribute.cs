using System;

[AttributeUsage(AttributeTargets.Method)]
public class MessageInputAttribute : Attribute
{
    public string Message { get; set; }

    public MessageInputAttribute(string message)
    {
        Message = message;
    }
}