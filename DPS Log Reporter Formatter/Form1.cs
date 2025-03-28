using System.Diagnostics.CodeAnalysis;

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
        {"ai", "Ai, Keeper of the Peak"},
        // Silent Surf
        {"kana", "Kanaxai, Scythe of House Aurkus"},
        // TODO Lonely Tower
        
        // Uncategorized
        {"golem", "Golem"}, {"wvw", "World Versus World"},

    };

    private void buttonFormat_Click(object sender, EventArgs e)
    {
        // Setup Markup
        AssignMarkup();

        string previousTitle = "";
        string listedLogs = textBoxLinks.Text;
        string formattedLogs = Write("LOGS", Markup.Title);
        using (StringReader reader = new StringReader(listedLogs))
        {
            while (true)
            {
                var line = reader.ReadLine();
                if (line == null)
                    break;
                var key = line.Split("_")[1];
                if (_logCategories.ContainsKey(key))
                    formattedLogs += Write("UNKNOWN LOG", Markup.Category);
                else if (_logCategories[key] != previousTitle)
                {
                    previousTitle = _logCategories[key];
                    formattedLogs += Write(previousTitle, Markup.Category);
                }
                formattedLogs += Write(line, Markup.None);
            }
        }
        textBoxFormatted.Text = formattedLogs;
    }

    #region Markup
    //Markup
    private string _titleMarkup, _headerMarkup, _categoryMarkup;
    private void AssignMarkup()
    {
        _titleMarkup = "";
        _headerMarkup = "";
        _categoryMarkup = "";

        if (comboboxMarkup.Text != "Discord")
            return;
        _titleMarkup = "__**";
        _headerMarkup = "**";
        _categoryMarkup = "***";
    }

    private string Write(string text, Markup markup)
    {
        var usedMarkup = markup switch
        {
            Markup.Title => _titleMarkup,
            Markup.Header => _headerMarkup,
            Markup.Category => _categoryMarkup,
            _ => ""
        };
        return usedMarkup + text + usedMarkup + "\r\n";
    }

    public enum Markup
    {
        Title,
        Header,
        Category,
        None
    }
    #endregion
}