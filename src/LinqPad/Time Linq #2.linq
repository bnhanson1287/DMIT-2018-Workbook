<Query Kind="Statements" />

// Goofin off with times
DateTime today = DateTime.Today;
var fiveDaysLater = today.AddDays(5);
fiveDaysLater.Dump();
var delay = new TimeSpan(49, 15, 22);
delay.Dump();
today.Add(delay).Dump();
today.ToString("MMM dd yyy").Dump();