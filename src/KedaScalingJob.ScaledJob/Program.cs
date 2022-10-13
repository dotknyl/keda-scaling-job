//using StackExchange.Redis;

//var muxer = ConnectionMultiplexer.Connect("localhost:6379");
//var db = muxer.GetDatabase(2);
//const string streamName = "keda-scaling-job";
//const string groupName = "dev";

//if (!(await db.KeyExistsAsync(streamName)) ||
//    (await db.StreamGroupInfoAsync(streamName)).All(x => x.Name != groupName))
//{
//    await db.StreamCreateConsumerGroupAsync(streamName, groupName, "0-0", true);
//}

//Dictionary<string, string> ParseResult(StreamEntry entry) => entry.Values.ToDictionary(x => x.Name.ToString(), x => x.Value.ToString());


//var result = await db.StreamReadGroupAsync(streamName, groupName, Guid.NewGuid().ToString(), ">", 1);
//if (result.Any())
//{
//    string id = result.First().Id;
//    var dict = ParseResult(result.First());
//    Console.WriteLine($"Job Id: {dict["id"]}");
//    await db.StreamAcknowledgeAsync(streamName, groupName, id);
//}

var random = new Random();
int time = random.Next(5000, 10000);
Console.WriteLine($"Delay {time} before closed!");
await Task.Delay(time);
