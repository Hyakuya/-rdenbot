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
                x.PrefixChar = '-';
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
                    await e.Channel.SendFile("Pictures/admin.jpg");
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

            commands.CreateCommand("amd")
             .Do(async (e) =>
             {
                 await e.Channel.SendFile("Pictures/amd.jpg");
             });
            commands.CreateCommand("intel")
             .Do(async (e) =>
             {
                 await e.Channel.SendFile("Pictures/intel.jpg");
             });
            commands.CreateCommand("nvidia")
             .Do(async (e) =>
             {
                 await e.Channel.SendFile("Pictures/intel.jpg");
             });
            commands.CreateCommand("zlatan")
             .Do(async (e) =>
             {
                 await e.Channel.SendFile("Pictures/zlatan.jpg");
             });
            commands.CreateCommand("lol")
             .Do(async (e) =>
             {
                 await e.Channel.SendFile("Pictures/laught.gif");
             });


            commands.CreateCommand("hannes")
               .Do(async (e) =>
               {
                   await e.Channel.SendFile("Pictures/hannes.jpg");
               });

            commands.CreateCommand("pepe")
               .Do(async (e) =>
               {
                   await e.Channel.SendFile("Pictures/wille.jpg");
               });
           

            commands.CreateCommand("help")
               .Do(async (e) =>
               {
                   await e.User.SendMessage("commands: Hi - hello - bye - admin - zlatan - hannes - pepe - felix - intel - amd");
               });
            commands.CreateCommand("felix")
               .Do(async (e) =>
               {
                   await e.Channel.SendFile("Pictures/felix.jpg");
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



