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
    private readonly Dictionary<string, string> _logCategories = new Dictionary<string, string> // <log _ ending, Name>
    {
        // RAIDS
        // Wing 1 - Spirit Vale
        {"vg", "Vale Guardian"}, {"race", "Ethereal Barrier"}, {"gors", "Gorseval the Multifarious"}, {"sab", "Sabetha the Saboteur"}, 
        // Wing 2 - Salvation Pass
        {"sloth", "Slothasor"}, {"trio", "Bandit Trio"}, {"matt", "Matthias Gabrel"}, 
        // Wing 3 - Stronghold of the Faithful
        {"esc", "Escort"}, {"kc", "Keep Construct"}, {"tc", "Twisted Castle"}, {"xera", "Xera"}, 
        // Wing 4 - Bastion of the Penitent
        {"cairn", "Cairn the Indomitable"}, {"mo", "Mursaat Overseer"}, {"sam", "Samarog"}, {"dei", "Deimos"}, 
        // Wing 5 - Hall of Chains
        {"sh", "Soulless Horror"}, {"rr", "River of Souls"}, {"bk", "Broken King"}, {"se", "Eater of Souls"}, {"eyes", "Statue of Darkness"}, {"dhuum", "Dhuum"}, 
        // Wing 6 - Mythwright Gambit
        {"ca", "Conjured Amalgamate"}, {"twins", "Twin Largos"}, {"qadim", "Qadim"}, 
        // Wing 7 - The Key of Ahdashim
        {"adina", "Cardinal Adina"}, {"sabir", "Cardinal Sabir"}, {"qpeer", "Qadim the Peerless"}, 
        // Wing 8 - Mount Balrior
        {"greer", "Greer, The Blightbringer"}, {"deci", "Decima, the Stormsinger"}, {"ura", "Ura, the Steamshrieker"},
        
        // STRIKES
        // Icebrood Saga
        {"ice", "Icebrood Construct"}, {"falln", "The Voice and the Claw"}, {"frae", "Fraenir of Jormag"}, {"bone", "Boneskinner"}, {"whisp", "Whisper of Jormag"},
        // End of Dragons
        {"trin", "Aetherblade Hideout"}, {"ankka", "Xunlai Jade Junkyard"}, {"li", "Kaineng Overlook"}, {"void", "Harvest Temple"}, {"olc", "Old Lion's Court"}, 
        // Secrets of the Obscure
        {"dagda", "Cosmic Observatory"}, {"cerus", "Temple of Febe"},
        
        // Fractals
        // Nightmare
        {"mama", "MAMA"}, {"siax", "Siax the Corrupted"}, {"enso", "Ensolyss of the Endless Torment"},
        // Shattered Observatory
        {"skor", "Skorvald"}, {"arriv", "Artsariiv"}, {"arkk", "Arkk"},
        // Sunqua Peak
        {"ai", "Ai, Keeper of the Peak"}, // This is for Elemental & Dark Ai
        // Silent Surf
        {"kana", "Kanaxai, Scythe of House Aurkus"},
        // Lonely Tower
        {"eparc", "Eparch"},
        
        // Uncategorized
        {"golem", "Golem"}, {"wvw", "World Versus World"},

    };

    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    [SuppressMessage("ReSharper", "CommentTypo")]
    private static string SelectHeader(string key)
    {
        return key switch
        {
            // Raids
            "vg" or "race" or "gors" or "sab" => "Raid Wing 1 - Spirit Vale",
            "sloth" or "trio" or "matt" => "Raid Wing 2 - Salvation Pass",
            "esc" or "kc" or "tc" or "xera" => "Raid Wing 3 - Stronghold of the Faithful",
            "cairn" or "mo" or "sam" or "dei" => "Raid Wing 4 - Bastion of the Penitent",
            "sh" or "rr" or "bk" or "se" or "eyes" or "dhuum" => "Raid Wing 5 - Hall of Chains",
            "ca" or "twins" or "qadim" => "Raid Wing 6 - Mythwright Gambit",
            "adina" or "sabir" or "qpeer" => "Raid Wing 7 - The Key of Ahdashim",
            "greer" or "deci" or "ura" => "Raid Wing 8 - Mount Balrior",
            // Strikes
            "ice" or "falln" or "frae" or "bone" or "whisp" => "Icebrood Saga Strikes",
            "trin" or "ankka" or "li" or "void" or "olc" => "End of Dragons Strikes",
            "dagda" or "cerus" => "Secrets of the Obscure Strikes",
            // Fractals
            "mama" or "siax" or "enso" => "Nightmare Fractal",
            "skor" or "arriv" or "arkk" => "Shattered Observatory Fractal",
            "ai" => "Sunqua Peak Fractal",
            "kana" => "Silent Surf Fractal",
            "eparc" => "Lonely Tower Fractal",
            // Uncategorized
            "golem" or "wvw" => "Uncategorized",
            _ => "Unknown"
        };
    }

    private void buttonFormat_Click(object sender, EventArgs e)
    {
        // Setup Initial Info
        AssignMarkup();
        AssignClassification();

        var previousHeader = "";
        var previousCategory = "";
        var listedLogs = textBoxLinks.Text;
        var formattedLogs = Write("LOGS", Markup.Title);
        using (var reader = new StringReader(listedLogs))
        {
            while (true)
            {
                var line = reader.ReadLine();
                if (line == null)
                    break;
                var key = line.Split("_")[1];
                if (_showHeader && !_logCategories.ContainsKey(key))
                    formattedLogs += Write("UNKNOWN LOG", Markup.Header);
                else if ((_showCategory || _showHeader) && _logCategories[key] != previousCategory)
                {
                    var header = SelectHeader(key);
                    if (_showHeader && previousHeader != header)
                    {
                        previousHeader = header;
                        formattedLogs += Write(header, Markup.Header);
                    }

                    if (_showCategory)
                    {
                        previousCategory = _logCategories[key];
                        formattedLogs += Write(previousCategory, Markup.Category);
                    }
                }
                
                // Check if successful kill
                using (var wc = new WebClient())
                {
                    var text = wc.DownloadString(line);
                    if (text.Contains("\"hpLeft\":0,"))
                        formattedLogs += "Kill Log: ";
                }
                
                // Write Log
                formattedLogs += Write(line, Markup.None);
            }
        }
        
        textBoxFormatted.Text = formattedLogs;
    }
    
    #region Markup
    //Markup
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