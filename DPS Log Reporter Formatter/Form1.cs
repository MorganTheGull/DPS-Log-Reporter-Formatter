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
        // RAIDS
        // Wing 1 - Spirit Vale
        {"vg", new FightInfo {Category = "Vale Guardian", Header = "Raid Wing 1 - Spirit Vale"}},
        {"race", new FightInfo {Category = "Ethereal Barrier", Header = "Raid Wing 1 - Spirit Vale", TrackedEnemies = 4}},
        {"gors", new FightInfo {Category = "Gorseval the Multifarious", Header = "Raid Wing 1 - Spirit Vale"}},
        {"sab", new FightInfo {Category = "Sabetha the Saboteur", Header = "Raid Wing 1 - Spirit Vale"}},
        // Wing 2 - Salvation Pass
        {"sloth", new FightInfo {Category = "Slothasor", Header = "Raid Wing 2 - Salvation Pass"}},
        {"trio", new FightInfo {Category = "Bandit Trio", Header = "Raid Wing 2 - Salvation Pass", TrackedEnemies = 3}},
        {"matt", new FightInfo {Category = "Matthias Gabrel", Header = "Raid Wing 2 - Salvation Pass"}},
        // Wing 3 - Stronghold of the Faithful
        {"esc", new FightInfo {Category = "Escort", Header = "Raid Wing 3 - Stronghold of the Faithful"}},
        {"kc", new FightInfo {Category = "Keep Construct", Header = "Raid Wing 3 - Stronghold of the Faithful"}},
        {"tc", new FightInfo {Category = "Twisted Castle", Header = "Raid Wing 3 - Stronghold of the Faithful"}},
        {"xera", new FightInfo {Category = "Xera", Header = "Raid Wing 3 - Stronghold of the Faithful"}},
        // Wing 4 - Bastion of the Penitent
        {"cairn", new FightInfo {Category = "Cairn the Indomitable", Header = "Raid Wing 4 - Bastion of the Penitent"}},
        {"mo", new FightInfo {Category = "Mursaat Overseer", Header = "Raid Wing 4 - Bastion of the Penitent"}},
        {"sam", new FightInfo {Category = "Samarog", Header = "Raid Wing 4 - Bastion of the Penitent"}},
        {"dei", new FightInfo {Category = "Deimos", Header = "Raid Wing 4 - Bastion of the Penitent"}},
        // Wing 5 - Hall of Chains
        {"sh", new FightInfo {Category = "Soulless Horror", Header = "Raid Wing 5 - Hall of Chains"}},
        {"rr", new FightInfo {Category = "River of Souls", Header = "Raid Wing 5 - Hall of Chains"}},
        {"bk", new FightInfo {Category = "Broken King", Header = "Raid Wing 5 - Hall of Chains"}},
        {"se", new FightInfo {Category = "Eater of Souls", Header = "Raid Wing 5 - Hall of Chains"}},
        {"eyes", new FightInfo {Category = "Statue of Darkness", Header = "Raid Wing 5 - Hall of Chains"}},
        {"dhuum", new FightInfo {Category = "Dhuum", Header = "Raid Wing 5 - Hall of Chains"}},
        // Wing 6 - Mythwright Gambit
        {"ca", new FightInfo {Category = "Conjured Amalgamate", Header = "Raid Wing 6 - Mythwright Gambit"}},
        {"twins", new FightInfo {Category = "Twin Largos", Header = "Raid Wing 6 - Mythwright Gambit", TrackedEnemies = 2}},
        {"qadim", new FightInfo {Category = "Qadim", Header = "Raid Wing 6 - Mythwright Gambit"}},
        // Wing 7 - The Key of Ahdashim
        {"adina", new FightInfo {Category = "Cardinal Adina", Header = "Raid Wing 7 - The Key of Ahdashim"}},
        {"sabir", new FightInfo {Category = "Cardinal Sabir", Header = "Raid Wing 7 - The Key of Ahdashim"}},
        {"qpeer", new FightInfo {Category = "Qadim the Peerless", Header = "Raid Wing 7 - The Key of Ahdashim"}},
        // Wing 8 - Mount Balrior
        {"greer", new FightInfo {Category = "Greer, the Blightbringer", Header = "Raid Wing 8 - Mount Balrior"}},
        {"deci", new FightInfo {Category = "Decima, the Stormsinger", Header = "Raid Wing 8 - Mount Balrior"}},
        {"ura", new FightInfo {Category = "Ura, the Steamshrieker", Header = "Raid Wing 8 - Mount Balrior"}},
        
        // STRIKES
        // Icebrood Saga
        {"ice", new FightInfo {Category = "Icebrood Construct", Header = "Icebrood Saga Strikes"}},
        {"falln", new FightInfo {Category = "The Voice and the Claw", Header = "Icebrood Saga Strikes"}},
        {"frae", new FightInfo {Category = "Fraenir of Jormag", Header = "Icebrood Saga Strikes"}},
        {"bone", new FightInfo {Category = "Boneskinner", Header = "Icebrood Saga Strikes"}},
        {"whisp", new FightInfo {Category = "Whisper of Jormag", Header = "Icebrood Saga Strikes"}},
        // End of Dragons
        {"trin", new FightInfo {Category = "Aetherblade Hideout", Header = "End of Dragons Strikes"}},
        {"ankka", new FightInfo {Category = "Xunlai Jade Junkyard", Header = "End of Dragons Strikes"}},
        {"li", new FightInfo {Category = "Kaineng Overlook", Header = "End of Dragons Strikes"}},
        {"void", new FightInfo {Category = "Harvest Temple", Header = "End of Dragons Strikes", TrackedEnemies = 9}},
        {"olc", new FightInfo {Category = "Old Lion's Court", Header = "End of Dragons Strikes", TrackedEnemies = 3}},
        // Secrets of the Obscure
        {"dagda", new FightInfo {Category = "Cosmic Observatory", Header = "Secrets of the Obscure Strikes"}},
        {"Cerus", new FightInfo {Category = "Temple of Febe", Header = "Secrets of the Obscure Strikes"}},
        
        // Fractals
        // Nightmare
        {"mama", new FightInfo {Category = "MAMA", Header = "Nightmare Fractal"}},
        {"siax", new FightInfo {Category = "Siax the Corrupted", Header = "Nightmare Fractal"}},
        {"enso", new FightInfo {Category = "Ensolyss of the Endless Torment", Header = "Nightmare Fractal"}},
        // Shattered Observatory
        {"skor", new FightInfo {Category = "Skorvald", Header = "Shattered Observatory Fractal"}},
        {"arriv", new FightInfo {Category = "Artsariiv", Header = "Shattered Observatory Fractal"}},
        {"arkk", new FightInfo {Category = "Arkk", Header = "Shattered Observatory Fractal"}},
        // Sunqua Peak
        {"ai", new FightInfo {Category = "Ai, Keeper of the Peak", Header = "Sunqua Peak Fractal"}}, // Elemental or Dark Ai
        // Silent Surf
        {"kana", new FightInfo {Category = "Kanaxai, Scythe of House Aurkus", Header = "Silent Surf Fractal"}},
        // Lonely Tower
        {"eparc", new FightInfo {Category = "Eparch", Header = "Lonely Tower Fractal"}},
        // Kinfall
        {"boss", new FightInfo {Category = "Whispering Shadow", Header = "Kinfall Fractal"}}, // TODO Swap 'boss' to kinfall fractals code once its added
        
        // Uncategorized
        {"golem", new FightInfo {Category = "Golem", Header = "Uncategorized"}},
        {"wvw", new FightInfo {Category = "World Versus World", Header = "Uncategorized"}},
        // {"boss", new FightInfo {Category = "Uncategorized Boss", Header = "Uncategorized"}}, // TODO Re-Enable this once Kinfall Fractal boss gets its own code
    };

    private async void buttonFormat_Click(object sender, EventArgs e)
    {
        buttonFormat.Enabled = false;
        buttonFormat.Text = "Formatting ...";
        
        // Setup Initial Info
        AssignMarkup();
        AssignClassification();
        
        var client = new HttpClient();
        var checkingResponse = await client.GetAsync("https://dps.report/");
        var connected = checkingResponse.IsSuccessStatusCode;
        var errorConnecting = connected
            ? "" : "Unable to connect to `dps.report`. Kill logs not marked.";

        var previousHeader = "";
        var previousBossKey = "";
        var listedLogs = textBoxLinks.Text;
        var formattedLogs = Write("LOGS", Markup.Title);
        using (var reader = new StringReader(listedLogs))
        {
            while (true)
            {
                var line = reader.ReadLine();
                if (line == null)
                    break;
                if (!line.Contains('_'))
                    continue;
                var key = line.Split("_")[1];
                if (_showHeader && !_logCategories.ContainsKey(key))
                    formattedLogs += Write("UNKNOWN LOG", Markup.Header);
                else if ((_showCategory || _showHeader) && key != previousBossKey)
                {
                    var header = _logCategories[key].Header;
                    if (_showHeader && previousHeader != header)
                    {
                        previousHeader = header;
                        formattedLogs += Write(header, Markup.Header);
                    }

                    var category = _logCategories[key].Category;
                    if (_showCategory && previousBossKey != category)
                    {
                        previousBossKey = category;
                        formattedLogs += Write(category, Markup.Category);
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
                                formattedLogs += "Kill Log: ";
                        }
                    }
                    catch (Exception ex)
                    {
                        // ignored
                    }
                }

                // Write Log
                formattedLogs += Write(line, Markup.None);
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
        public string Category { get; init; } = "";
        public string Header { get; init; } = "";
        public int TrackedEnemies { get; init; } = 1;
    }
    
    #region Markup
    private string _titleMarkupStart, _titleMarkupEnd,
                   _headerMarkupStart, _headerMarkupEnd,
                   _categoryMarkupStart, _categoryMarkupEnd,
                   _endingMarkupStart, _endingMarkupEnd;

    private void AssignMarkup()
    {
        _titleMarkupStart = "";
        _titleMarkupEnd = "";
        _headerMarkupStart = "";
        _headerMarkupEnd = "";
        _categoryMarkupStart = "";
        _categoryMarkupEnd = "";
        _endingMarkupStart = "\r\n";
        _endingMarkupEnd = "";

        if (comboboxMarkup.Text != "Discord")
            return;
        _titleMarkupStart = "# __";
        _titleMarkupEnd = "__";
        _headerMarkupStart = "## ";
        _categoryMarkupStart = "***";
        _categoryMarkupEnd = "***";
        _endingMarkupStart = "\r\n-# ";
    }

    private string Write(string text, Markup markup)
    {
        var startMarkup = markup switch
        {
            Markup.Title => _titleMarkupStart,
            Markup.Header => _headerMarkupStart,
            Markup.Category => _categoryMarkupStart,
            Markup.Ending => _endingMarkupStart,
            _ => ""
        };
        var endMarkup = markup switch
        {
            Markup.Title => _titleMarkupEnd,
            Markup.Header => _headerMarkupEnd,
            Markup.Category => _categoryMarkupEnd,
            Markup.Ending => _endingMarkupEnd,
            _ => ""
        };
        return startMarkup + text + endMarkup + "\r\n";
    }

    public enum Markup
    {
        Title,
        Header,
        Category,
        Ending,
        None
    }
    #endregion
    
    #region Classifications

    private bool _showCategory;
    private bool _showHeader;
    
    private void AssignClassification()
    {
        _showCategory = false;
        _showHeader = false;
        switch (comboboxClassifications.Text)
        {
            case "All Categories":
                _showCategory = true;
                _showHeader = true;
                break;
            case "Only Main Categories":
                _showHeader = true;
                break;
            case "Only Sub Categories":
                _showCategory = true;
                break;
        }
    }
    #endregion
}