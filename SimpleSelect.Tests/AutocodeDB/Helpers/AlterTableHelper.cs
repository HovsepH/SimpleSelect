﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AutocodeDB.Models;
using AutocodeDB.SQLTemplates;
using Microsoft.Data.Sqlite;

namespace AutocodeDB.Helpers
{
    public static class AlterTableHelper
    {
        private const RegexOptions Options = RegexOptions.Compiled | RegexOptions.IgnoreCase;
        private static readonly Regex AlterTableRegex = new Regex(AlterTableEntity.Simple, Options);
        private static readonly Regex AddColumnRegex = new Regex(AlterTableEntity.AddColumn, Options);
        private static readonly Regex RenameColumnRegex = new Regex(AlterTableEntity.RenameColumn, Options);
        private static readonly Regex RenameTableRegex = new Regex(AlterTableEntity.RenameTable, Options);
        private static readonly Regex DropColumnRegex = new Regex(AlterTableEntity.DropColumn, Options);

        public static bool ContainsAlterTable(string query) => AlterTableRegex.IsMatch(query);

        public static bool ContainsAddColumn(string query) => AddColumnRegex.IsMatch(query);

        public static bool ContainsDropColumn(string query) => DropColumnRegex.IsMatch(query);

        public static bool ContainsRenameColumn(string query) => RenameColumnRegex.IsMatch(query);

        public static bool ContainsRenameTable(string query) => RenameTableRegex.IsMatch(query);
    }
}
