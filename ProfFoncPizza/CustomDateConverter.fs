module ProfFoncPizza.CustomDateConverter

open System
open System.Text.Json
open System.Text.Json.Serialization

type CustomDateTimeConverter() =
    inherit JsonConverter<DateTime>()
    override _.Read(reader, _, _) =
        let dateStr = reader.GetString()
        match DateTime.TryParse(dateStr) with
        | (true, date) -> date
        | (false, _) -> raise (FormatException($"Invalid date format: {dateStr}"))

    override _.Write(writer, value, _) =
        writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss"))  // You can customize the output format here if needed

