using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace DPS_Log_Reporter_Formatter;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    [SuppressMessage("ReSharper", "CommentTypo")]
    private readonly Dictionary<string, FightInfo> _logCategories = new() // <log _ ending, {BossName, HeaderName, TrackedEnemies = 1}>
    {
        // RAID WINGS
        // Wing 1 - Spirit Vale
        {"vg", new FightInfo {Boss = "Vale Guardian", Header = "Raid Wing 1 - Spirit Vale", Expansion = "Heart of Thorns"}},
        {"race", new FightInfo {Boss = "Traverse the Spirit Woods", Header = "Raid Wing 1 - Spirit Vale", Expansion = "Heart of Thorns", TrackedEnemies = 4}},
        {"gors", new FightInfo {Boss = "Gorseval the Multifarious", Header = "Raid Wing 1 - Spirit Vale", Expansion = "Heart of Thorns"}},
        {"sab", new FightInfo {Boss = "Sabetha the Saboteur", Header = "Raid Wing 1 - Spirit Vale", Expansion = "Heart of Thorns"}},
        // Wing 2 - Salvation Pass
        {"sloth", new FightInfo {Boss = "Slothasor", Header = "Raid Wing 2 - Salvation Pass", Expansion = "Heart of Thorns"}},
        {"trio", new FightInfo {Boss = "Bandit Trio", Header = "Raid Wing 2 - Salvation Pass", Expansion = "Heart of Thorns", TrackedEnemies = 3}},
        {"matt", new FightInfo {Boss = "Matthias Gabrel", Header = "Raid Wing 2 - Salvation Pass", Expansion = "Heart of Thorns"}},
        // Wing 3 - Stronghold of the Faithful
        {"esc", new FightInfo {Boss = "Siege the Stronghold", Header = "Raid Wing 3 - Stronghold of the Faithful", Expansion = "Heart of Thorns"}},
        {"kc", new FightInfo {Boss = "Keep Construct", Header = "Raid Wing 3 - Stronghold of the Faithful", Expansion = "Heart of Thorns"}},
        {"tc", new FightInfo {Boss = "Twisted Castle", Header = "Raid Wing 3 - Stronghold of the Faithful", Expansion = "Heart of Thorns"}},
        {"xera", new FightInfo {Boss = "Xera", Header = "Raid Wing 3 - Stronghold of the Faithful", Expansion = "Heart of Thorns"}},
        // Wing 4 - Bastion of the Penitent
        {"cairn", new FightInfo {Boss = "Cairn the Indomitable", Header = "Raid Wing 4 - Bastion of the Penitent", Expansion = "Heart of Thorns"}},
        {"mo", new FightInfo {Boss = "Mursaat Overseer", Header = "Raid Wing 4 - Bastion of the Penitent", Expansion = "Heart of Thorns"}},
        {"sam", new FightInfo {Boss = "Samarog", Header = "Raid Wing 4 - Bastion of the Penitent", Expansion = "Heart of Thorns"}},
        {"dei", new FightInfo {Boss = "Deimos", Header = "Raid Wing 4 - Bastion of the Penitent", Expansion = "Heart of Thorns"}},
        // Wing 5 - Hall of Chains
        {"sh", new FightInfo {Boss = "Soulless Horror", Header = "Raid Wing 5 - Hall of Chains", Expansion = "Path of Fire"}},
        {"rr", new FightInfo {Boss = "River of Souls", Header = "Raid Wing 5 - Hall of Chains", Expansion = "Path of Fire"}},
        {"bk", new FightInfo {Boss = "Broken King", Header = "Raid Wing 5 - Hall of Chains", Expansion = "Path of Fire"}},
        {"se", new FightInfo {Boss = "Eater of Souls", Header = "Raid Wing 5 - Hall of Chains", Expansion = "Path of Fire"}},
        {"eyes", new FightInfo {Boss = "Statue of Darkness", Header = "Raid Wing 5 - Hall of Chains", Expansion = "Path of Fire"}},
        {"dhuum", new FightInfo {Boss = "Dhuum", Header = "Raid Wing 5 - Hall of Chains", Expansion = "Path of Fire"}},
        // Wing 6 - Mythwright Gambit
        {"ca", new FightInfo {Boss = "Conjured Amalgamate", Header = "Raid Wing 6 - Mythwright Gambit", Expansion = "Path of Fire"}},
        {"twins", new FightInfo {Boss = "Twin Largos", Header = "Raid Wing 6 - Mythwright Gambit", Expansion = "Path of Fire", TrackedEnemies = 2}},
        {"qadim", new FightInfo {Boss = "Qadim", Header = "Raid Wing 6 - Mythwright Gambit", Expansion = "Path of Fire"}},
        // Wing 7 - The Key of Ahdashim
        {"adina", new FightInfo {Boss = "Cardinal Adina", Header = "Raid Wing 7 - The Key of Ahdashim", Expansion = "Path of Fire"}},
        {"sabir", new FightInfo {Boss = "Cardinal Sabir", Header = "Raid Wing 7 - The Key of Ahdashim", Expansion = "Path of Fire"}},
        {"qpeer", new FightInfo {Boss = "Qadim the Peerless", Header = "Raid Wing 7 - The Key of Ahdashim", Expansion = "Path of Fire"}},
        // Wing 8 - Mount Balrior
        {"greer", new FightInfo {Boss = "Greer, the Blightbringer", Header = "Raid Wing 8 - Mount Balrior", Expansion = "Janthir Wilds"}},
        {"deci", new FightInfo {Boss = "Decima, the Stormsinger", Header = "Raid Wing 8 - Mount Balrior", Expansion = "Janthir Wilds"}},
        {"ura", new FightInfo {Boss = "Ura, the Steamshrieker", Header = "Raid Wing 8 - Mount Balrior", Expansion = "Janthir Wilds"}},
        
        // RAIDS
        // Core Game
        {"olc", new FightInfo {Boss = "Watchknight Triumvirate", Header = "Old Lion's Court", Expansion = "Core Game", TrackedEnemies = 3}},
        {"frezi", new FightInfo {Boss = "Freezie", Header = "Secret Lair of the Snowmen", Expansion = "Core Game"}},
        // Icebrood Saga
        {"ice", new FightInfo {Boss = "Legendary Icebrood Construct", Header = "Shiverpeaks Pass", Expansion = "The Icebrood Saga"}},
        {"falln", new FightInfo {Boss = "The Voice and the Claw", Header = "The Voice of the Fallen and Claw of the Fallen", Expansion = "The Icebrood Saga", TrackedEnemies = 2}},
        {"frae", new FightInfo {Boss = "Fraenir of Jormag", Header = "Fraenir of Jormag", Expansion = "The Icebrood Saga"}},
        {"bone", new FightInfo {Boss = "Boneskinner", Header = "Boneskinner", Expansion = "The Icebrood Saga"}},
        {"whisp", new FightInfo {Boss = "Whisper of Jormag", Header = "Whisper of Jormag", Expansion = "The Icebrood Saga"}},
        // End of Dragons
        {"trin", new FightInfo {Boss = "Captain Mai Trin", Header = "Aetherblade Hideout", Expansion = "End of Dragons"}},
        {"ankka", new FightInfo {Boss = "Ankka", Header = "Xunlai Jade Junkyard", Expansion = "End of Dragons"}},
        {"li", new FightInfo {Boss = "Minister Li", Header = "Kaineng Overlook", Expansion = "End of Dragons"}}, // TODO - Check to see if need tracked enemies for Enforcer, Ritualist, Mindblade, Mech Rider & Sniper
        {"void", new FightInfo {Boss = "The Dragonvoid", Header = "Harvest Temple", Expansion = "End of Dragons", TrackedEnemies = 9}},
        // Secrets of the Obscure
        {"dagda", new FightInfo {Boss = "Dagda", Header = "Cosmic Observatory", Expansion = "Secrets of the Obscure"}},
        {"cerus", new FightInfo {Boss = "Cerus", Header = "Temple of Febe", Expansion = "Secrets of the Obscure"}},
        // Visions of Eternity
        {"boss", new FightInfo {Boss = "Kela, Seneschal of Waves", Header = "Guardian's Glade", Expansion = "Visions of Eternity"}},
        
        // FRACTALS
        // Nightmare
        {"mama", new FightInfo {Boss = "MAMA", Header = "Nightmare", Expansion = "Fractals"}},
        {"siax", new FightInfo {Boss = "Siax the Corrupted", Header = "Nightmare", Expansion = "Fractals"}},
        {"enso", new FightInfo {Boss = "Ensolyss of the Endless Torment", Header = "Nightmare", Expansion = "Fractals"}},
        // Shattered Observatory
        {"skor", new FightInfo {Boss = "Skorvald", Header = "Shattered Observatory", Expansion = "Fractals"}},
        {"arriv", new FightInfo {Boss = "Artsariiv", Header = "Shattered Observatory", Expansion = "Fractals"}},
        {"arkk", new FightInfo {Boss = "Arkk", Header = "Shattered Observatory", Expansion = "Fractals"}},
        // Sunqua Peak
        {"ai", new FightInfo {Boss = "Ai, Keeper of the Peak", Header = "Sunqua Peak", Expansion = "Fractals"}}, // Elemental or Dark Ai
        // Silent Surf
        {"kana", new FightInfo {Boss = "Kanaxai, Scythe of House Aurkus", Header = "Silent Surf", Expansion = "Fractals"}},
        // Lonely Tower
        {"eparc", new FightInfo {Boss = "Eparch", Header = "Lonely Tower", Expansion = "Fractals"}},
        // Kinfall
        {"ws", new FightInfo {Boss = "Whispering Shadow", Header = "Kinfall", Expansion = "Fractals"}},
        
        // UNCATEGORIZED
        {"golem", new FightInfo {Boss = "Golem", Expansion = "Uncategorized"}},
        {"wvw", new FightInfo {Boss = "World Versus World", Expansion = "Uncategorized"}},
        // {"boss", new FightInfo {Category = "Uncategorized Boss", Header = "Uncategorized"}}, // TODO Re-Enable this once Guardian's Glade boss gets its own code
    };

    private async void buttonFormat_Click(object sender, EventArgs e)
    {
        buttonFormat.Enabled = false;
        buttonFormat.Text = "Formatting ...";
        
        // Setup Initial Info
        AssignMarkup();
        
        var client = new HttpClient();
        var checkingResponse = await client.GetAsync("https://dps.report/");
        var connected = checkingResponse.IsSuccessStatusCode;
        var errorConnecting = connected
            ? "" : "Unable to connect to `dps.report`. Kill logs not marked.";

        var previousExpansion = "";
        var previousHeader = "";
        var previousBossKey = "";
        var listedLogs = textBoxLinks.Text;
        var formattedLogs = "";
        using (var reader = new StringReader(listedLogs))
        {
            while (true)
            {
                var preface = "> ";
                var line = reader.ReadLine();
                if (line == null)
                    break;
                if (!line.Contains('_'))
                    continue;
                var key = line.Split("_")[1];
                if (!_logCategories.ContainsKey(key))
                    formattedLogs += Write("UNKNOWN LOG", Markup.Expansion);
                else if (key != previousBossKey)
                {
                    var expansion = _logCategories[key].Expansion;
                    if (previousExpansion != expansion)
                    {
                        previousExpansion = expansion;
                        formattedLogs += Write(expansion, Markup.Expansion);
                    }
                    
                    var header = _logCategories[key].Header;
                    if (previousHeader != header && header != "")
                    {
                        previousHeader = header;
                        formattedLogs += Write(header, Markup.Header);
                    }

                    var boss = _logCategories[key].Boss;
                    if (previousBossKey != boss)
                    {
                        previousBossKey = boss;
                        formattedLogs += Write(boss, Markup.Boss);
                    }
                }
                
                if (connected)
                {
                    try
                    {
                        // Check if successful kill
                        const string searchFor = "\"hpLeft\"";
                        using (var wc = new WebClient())
                        {
                            var text = wc.DownloadString(line);
                            var successfulKill = true;
                            var previousKills = 0;
                            var hpCheck = _logCategories[key].TrackedEnemies;
                            for (var i = 0; i < hpCheck; i++)
                            {
                                previousKills = text.IndexOf(searchFor, previousKills, StringComparison.Ordinal);
                                var substring = text.Substring(previousKills, "\"hpLeft\":0,".Length);
                                previousKills++;
                                if ((!substring.Contains("\"hpLeft\":0,")))
                                    successfulKill = false;
                            }

                            if (successfulKill)
                            {
                                preface = "";
                                formattedLogs += "> **Kill Log → ** ";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // ignored
                    }
                }

                // Write Log
                formattedLogs += Write(preface + line, Markup.None);
            }
        }

        // Any error connecting?
        
        if (!checkingResponse.IsSuccessStatusCode)
            formattedLogs += Write(errorConnecting, Markup.Ending);
        
        textBoxFormatted.Text = formattedLogs;
        buttonFormat.Enabled = true;
        buttonFormat.Text = "Format";
    }

    public class FightInfo
    {
        public string Expansion { get; init; } = "";
        public string Header { get; init; } = "";
        public string Boss { get; init; } = "";
        public int TrackedEnemies { get; init; } = 1;
    }
    
    #region Markup
    private string _expansionMarkupStart, _expansionMarkupEnd,
                   _headerMarkupStart, _headerMarkupEnd,
                   _bossMarkupStart, _bossMarkupEnd,
                   _endingMarkupStart, _endingMarkupEnd;

    private void AssignMarkup()
    {
        _expansionMarkupStart = _expansionMarkupEnd = "";
        _headerMarkupStart = _headerMarkupEnd = "";
        _bossMarkupStart = _bossMarkupEnd = "";
        _endingMarkupStart = "\r\n";
        _endingMarkupEnd = "";

        if (comboboxMarkup.Text != "Discord")
            return;
        _expansionMarkupStart = "# __";
        _expansionMarkupEnd = "__";
        _headerMarkupStart = "## ";
        _bossMarkupStart = "__**";
        _bossMarkupEnd = "**__";
        _endingMarkupStart = "\r\n-# ";
    }

    private string Write(string text, Markup markup)
    {
        var startMarkup = markup switch
        {
            Markup.Expansion => _expansionMarkupStart,
            Markup.Header => _headerMarkupStart,
            Markup.Boss => _bossMarkupStart,
            Markup.Ending => _endingMarkupStart,
            _ => ""
        };
        var endMarkup = markup switch
        {
            Markup.Expansion => _expansionMarkupEnd,
            Markup.Header => _headerMarkupEnd,
            Markup.Boss => _bossMarkupEnd,
            Markup.Ending => _endingMarkupEnd,
            _ => ""
        };
        return startMarkup + text + endMarkup + "\r\n";
    }

    public enum Markup
    {
        Expansion,
        Header,
        Boss,
        Ending,
        None
    }
    #endregion
}
