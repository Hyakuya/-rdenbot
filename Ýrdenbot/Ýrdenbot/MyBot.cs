using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÝrdesBot
{
    class MyBot
    {
        DiscordClient discord;
        

        public MyBot()
        {
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '§';
                x.AllowMentionPrefix = true;


            });
            discord.UserJoined += async (s, e) =>
            {
                var channel = e.Server.FindChannels("lobby", ChannelType.Text).FirstOrDefault();
                var user = e.User;
                await channel.SendMessage(string.Format("{0} has joined the server", user.Name));
            };

            discord.UserBanned += async (s, e) =>
            {
                var channel = e.Server.FindChannels("lobby", ChannelType.Text).FirstOrDefault();
                var user = e.User;
                await channel.SendMessage(string.Format("{0} has been banned", user.Name));
            };



            discord.UserLeft += async (s, e) =>
            {
                var channel = e.Server.FindChannels("lobby", ChannelType.Text).FirstOrDefault();
                var user = e.User;
                await channel.SendMessage(string.Format("{0} has left the server", user.Name));
            };

            discord.UserUnbanned  += async (s, e) =>
            {
                var channel = e.Server.FindChannels("lobby", ChannelType.Text).FirstOrDefault();
                var user = e.User;
                await channel.SendMessage(string.Format("{0} has been unbanned", user.Name));
            };

            var commands = discord.GetService<CommandService>();


            commands.CreateCommand("hi")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Anaria shola");
                });
            commands.CreateCommand("admin")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Hyakuya and Darkmatter");
                });
            commands.CreateCommand("bye")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Al diel shala");
                });
            commands.CreateCommand("hello")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Bal'a dash, malanore");
                });
            commands.CreateCommand("idiot")
               .Do(async (e) =>
               {
                   await e.Channel.SendMessage("Hannes");
               });
            commands.CreateCommand("commands")
               .Do(async (e) =>
               {
                   await e.Channel.SendMessage("Hi - hello - bye - admin - idiot");
               });
            commands.CreateCommand("help")
               .Do(async (e) =>
               {
                   await e.Channel.SendMessage("Hi - hello - bye - admin - idiot");
               });

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("Mjc4MjQyMDQ3MzE0MzYyMzY4.C3pcnQ.I2AlEOXPOymTIeDNgcPYgzX9YWE", TokenType.Bot);
                
            });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }


}
