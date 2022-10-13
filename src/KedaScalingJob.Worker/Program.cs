using StackExchange.Redis;

var muxer = ConnectionMultiplexer.Connect("knyl.me:6379");
var db = muxer.GetDatabase(2);
const string streamName = "keda-scaling-job";
const string groupName = "dev";

if (!(await db.KeyExistsAsync(streamName)) ||
    (await db.StreamGroupInfoAsync(streamName)).All(x => x.Name != groupName))
{
    await db.StreamCreateConsumerGroupAsync(streamName, groupName);
}


int totalRecords = 100; // -1
int i = 0;
var random = new Random();

while (true)
{
    await db.StreamAddAsync(streamName, new NameValueEntry[] { new("id", i) });
    i++;
    Console.WriteLine($"Stream Add: {i}");
    await Task.Delay(random.Next(1000, 5000));
    if (i == totalRecords) break;
}
