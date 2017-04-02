namespace NewDarkLoader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbMaxYear = new System.Windows.Forms.ComboBox();
            this.cbMaxMonth = new System.Windows.Forms.ComboBox();
            this.cbMinYear = new System.Windows.Forms.ComboBox();
            this.cbMinMonth = new System.Windows.Forms.ComboBox();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.lblArchive = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblProgressTitle = new System.Windows.Forms.Label();
            this.fmTable = new System.Windows.Forms.DataGridView();
            this.ArchiveOrDir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArchiveSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TitleHeading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rating_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Finished_ = new System.Windows.Forms.DataGridViewImageColumn();
            this.ReleaseDate_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LstPlayed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cmnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoMod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightClickFM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editFMDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanAllFMsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rescanThisFMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateFMiniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHideTags = new System.Windows.Forms.Button();
            this.gbTags = new System.Windows.Forms.GroupBox();
            this.btnTagPresets = new System.Windows.Forms.Button();
            this.lbTags = new System.Windows.Forms.ListBox();
            this.lblFMTags = new System.Windows.Forms.Label();
            this.btnRemoveTags = new System.Windows.Forms.Button();
            this.tagTree = new System.Windows.Forms.TreeView();
            this.btnAddNewTag = new System.Windows.Forms.Button();
            this.tbAddTag = new System.Windows.Forms.TextBox();
            this.btnAddExistTag = new System.Windows.Forms.Button();
            this.menuTags = new System.Windows.Forms.MenuStrip();
            this.tagPresetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mysteryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puzzleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.czechToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dutchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frenchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.germanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hungarianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.italianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.japaneseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.russianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spanishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.campaignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherProtagonistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unknownAuthorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnResetFilters = new System.Windows.Forms.Button();
            this.lblTagFilter = new System.Windows.Forms.Label();
            this.btnSetTagFilter = new System.Windows.Forms.Button();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.chkUnfinished = new System.Windows.Forms.CheckBox();
            this.btnFullScreenReadme = new System.Windows.Forms.Button();
            this.btnShowInBrowser = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.readmeBox = new System.Windows.Forms.RichTextBox();
            this.rightClickReadme = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.item1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnPlOriginal = new System.Windows.Forms.Button();
            this.btnPlFM = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnWebSearch = new System.Windows.Forms.Button();
            this.btnInstallOnly = new System.Windows.Forms.Button();
            this.btnTools = new System.Windows.Forms.Button();
            this.btnSetup = new System.Windows.Forms.Button();
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.dlgSelectFixFile = new System.Windows.Forms.OpenFileDialog();
            this.dlgSaveFMINI = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fmTable)).BeginInit();
            this.rightClickFM.SuspendLayout();
            this.gbTags.SuspendLayout();
            this.menuTags.SuspendLayout();
            this.rightClickReadme.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.cbMaxYear);
            this.splitContainer1.Panel1.Controls.Add(this.cbMaxMonth);
            this.splitContainer1.Panel1.Controls.Add(this.cbMinYear);
            this.splitContainer1.Panel1.Controls.Add(this.cbMinMonth);
            this.splitContainer1.Panel1.Controls.Add(this.pnlProgress);
            this.splitContainer1.Panel1.Controls.Add(this.fmTable);
            this.splitContainer1.Panel1.Controls.Add(this.btnRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnHideTags);
            this.splitContainer1.Panel1.Controls.Add(this.gbTags);
            this.splitContainer1.Panel1.Controls.Add(this.btnResetFilters);
            this.splitContainer1.Panel1.Controls.Add(this.lblTagFilter);
            this.splitContainer1.Panel1.Controls.Add(this.btnSetTagFilter);
            this.splitContainer1.Panel1.Controls.Add(this.tbFilter);
            this.splitContainer1.Panel1.Controls.Add(this.chkUnfinished);
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.btnFullScreenReadme);
            this.splitContainer1.Panel2.Controls.Add(this.btnShowInBrowser);
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Panel2.Controls.Add(this.readmeBox);
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            // 
            // cbMaxYear
            // 
            this.cbMaxYear.FormattingEnabled = true;
            this.cbMaxYear.Items.AddRange(new object[] {
            resources.GetString("cbMaxYear.Items"),
            resources.GetString("cbMaxYear.Items1"),
            resources.GetString("cbMaxYear.Items2"),
            resources.GetString("cbMaxYear.Items3"),
            resources.GetString("cbMaxYear.Items4"),
            resources.GetString("cbMaxYear.Items5"),
            resources.GetString("cbMaxYear.Items6"),
            resources.GetString("cbMaxYear.Items7"),
            resources.GetString("cbMaxYear.Items8"),
            resources.GetString("cbMaxYear.Items9"),
            resources.GetString("cbMaxYear.Items10"),
            resources.GetString("cbMaxYear.Items11"),
            resources.GetString("cbMaxYear.Items12"),
            resources.GetString("cbMaxYear.Items13"),
            resources.GetString("cbMaxYear.Items14"),
            resources.GetString("cbMaxYear.Items15"),
            resources.GetString("cbMaxYear.Items16"),
            resources.GetString("cbMaxYear.Items17"),
            resources.GetString("cbMaxYear.Items18"),
            resources.GetString("cbMaxYear.Items19"),
            resources.GetString("cbMaxYear.Items20"),
            resources.GetString("cbMaxYear.Items21"),
            resources.GetString("cbMaxYear.Items22"),
            resources.GetString("cbMaxYear.Items23"),
            resources.GetString("cbMaxYear.Items24"),
            resources.GetString("cbMaxYear.Items25"),
            resources.GetString("cbMaxYear.Items26"),
            resources.GetString("cbMaxYear.Items27"),
            resources.GetString("cbMaxYear.Items28"),
            resources.GetString("cbMaxYear.Items29"),
            resources.GetString("cbMaxYear.Items30"),
            resources.GetString("cbMaxYear.Items31"),
            resources.GetString("cbMaxYear.Items32"),
            resources.GetString("cbMaxYear.Items33"),
            resources.GetString("cbMaxYear.Items34"),
            resources.GetString("cbMaxYear.Items35"),
            resources.GetString("cbMaxYear.Items36"),
            resources.GetString("cbMaxYear.Items37"),
            resources.GetString("cbMaxYear.Items38"),
            resources.GetString("cbMaxYear.Items39"),
            resources.GetString("cbMaxYear.Items40"),
            resources.GetString("cbMaxYear.Items41"),
            resources.GetString("cbMaxYear.Items42"),
            resources.GetString("cbMaxYear.Items43"),
            resources.GetString("cbMaxYear.Items44"),
            resources.GetString("cbMaxYear.Items45"),
            resources.GetString("cbMaxYear.Items46"),
            resources.GetString("cbMaxYear.Items47"),
            resources.GetString("cbMaxYear.Items48"),
            resources.GetString("cbMaxYear.Items49"),
            resources.GetString("cbMaxYear.Items50"),
            resources.GetString("cbMaxYear.Items51"),
            resources.GetString("cbMaxYear.Items52"),
            resources.GetString("cbMaxYear.Items53"),
            resources.GetString("cbMaxYear.Items54"),
            resources.GetString("cbMaxYear.Items55"),
            resources.GetString("cbMaxYear.Items56"),
            resources.GetString("cbMaxYear.Items57"),
            resources.GetString("cbMaxYear.Items58"),
            resources.GetString("cbMaxYear.Items59"),
            resources.GetString("cbMaxYear.Items60"),
            resources.GetString("cbMaxYear.Items61"),
            resources.GetString("cbMaxYear.Items62"),
            resources.GetString("cbMaxYear.Items63"),
            resources.GetString("cbMaxYear.Items64"),
            resources.GetString("cbMaxYear.Items65"),
            resources.GetString("cbMaxYear.Items66"),
            resources.GetString("cbMaxYear.Items67"),
            resources.GetString("cbMaxYear.Items68"),
            resources.GetString("cbMaxYear.Items69"),
            resources.GetString("cbMaxYear.Items70"),
            resources.GetString("cbMaxYear.Items71"),
            resources.GetString("cbMaxYear.Items72"),
            resources.GetString("cbMaxYear.Items73"),
            resources.GetString("cbMaxYear.Items74"),
            resources.GetString("cbMaxYear.Items75"),
            resources.GetString("cbMaxYear.Items76"),
            resources.GetString("cbMaxYear.Items77"),
            resources.GetString("cbMaxYear.Items78"),
            resources.GetString("cbMaxYear.Items79"),
            resources.GetString("cbMaxYear.Items80"),
            resources.GetString("cbMaxYear.Items81"),
            resources.GetString("cbMaxYear.Items82"),
            resources.GetString("cbMaxYear.Items83"),
            resources.GetString("cbMaxYear.Items84"),
            resources.GetString("cbMaxYear.Items85"),
            resources.GetString("cbMaxYear.Items86"),
            resources.GetString("cbMaxYear.Items87"),
            resources.GetString("cbMaxYear.Items88"),
            resources.GetString("cbMaxYear.Items89"),
            resources.GetString("cbMaxYear.Items90"),
            resources.GetString("cbMaxYear.Items91"),
            resources.GetString("cbMaxYear.Items92"),
            resources.GetString("cbMaxYear.Items93"),
            resources.GetString("cbMaxYear.Items94"),
            resources.GetString("cbMaxYear.Items95"),
            resources.GetString("cbMaxYear.Items96"),
            resources.GetString("cbMaxYear.Items97"),
            resources.GetString("cbMaxYear.Items98"),
            resources.GetString("cbMaxYear.Items99"),
            resources.GetString("cbMaxYear.Items100"),
            resources.GetString("cbMaxYear.Items101"),
            resources.GetString("cbMaxYear.Items102"),
            resources.GetString("cbMaxYear.Items103"),
            resources.GetString("cbMaxYear.Items104"),
            resources.GetString("cbMaxYear.Items105"),
            resources.GetString("cbMaxYear.Items106"),
            resources.GetString("cbMaxYear.Items107"),
            resources.GetString("cbMaxYear.Items108"),
            resources.GetString("cbMaxYear.Items109"),
            resources.GetString("cbMaxYear.Items110"),
            resources.GetString("cbMaxYear.Items111"),
            resources.GetString("cbMaxYear.Items112"),
            resources.GetString("cbMaxYear.Items113"),
            resources.GetString("cbMaxYear.Items114"),
            resources.GetString("cbMaxYear.Items115"),
            resources.GetString("cbMaxYear.Items116"),
            resources.GetString("cbMaxYear.Items117"),
            resources.GetString("cbMaxYear.Items118"),
            resources.GetString("cbMaxYear.Items119"),
            resources.GetString("cbMaxYear.Items120"),
            resources.GetString("cbMaxYear.Items121"),
            resources.GetString("cbMaxYear.Items122"),
            resources.GetString("cbMaxYear.Items123"),
            resources.GetString("cbMaxYear.Items124"),
            resources.GetString("cbMaxYear.Items125"),
            resources.GetString("cbMaxYear.Items126"),
            resources.GetString("cbMaxYear.Items127"),
            resources.GetString("cbMaxYear.Items128"),
            resources.GetString("cbMaxYear.Items129"),
            resources.GetString("cbMaxYear.Items130"),
            resources.GetString("cbMaxYear.Items131"),
            resources.GetString("cbMaxYear.Items132"),
            resources.GetString("cbMaxYear.Items133"),
            resources.GetString("cbMaxYear.Items134"),
            resources.GetString("cbMaxYear.Items135"),
            resources.GetString("cbMaxYear.Items136"),
            resources.GetString("cbMaxYear.Items137"),
            resources.GetString("cbMaxYear.Items138"),
            resources.GetString("cbMaxYear.Items139"),
            resources.GetString("cbMaxYear.Items140"),
            resources.GetString("cbMaxYear.Items141"),
            resources.GetString("cbMaxYear.Items142"),
            resources.GetString("cbMaxYear.Items143"),
            resources.GetString("cbMaxYear.Items144"),
            resources.GetString("cbMaxYear.Items145"),
            resources.GetString("cbMaxYear.Items146"),
            resources.GetString("cbMaxYear.Items147"),
            resources.GetString("cbMaxYear.Items148"),
            resources.GetString("cbMaxYear.Items149"),
            resources.GetString("cbMaxYear.Items150"),
            resources.GetString("cbMaxYear.Items151"),
            resources.GetString("cbMaxYear.Items152"),
            resources.GetString("cbMaxYear.Items153"),
            resources.GetString("cbMaxYear.Items154"),
            resources.GetString("cbMaxYear.Items155"),
            resources.GetString("cbMaxYear.Items156"),
            resources.GetString("cbMaxYear.Items157"),
            resources.GetString("cbMaxYear.Items158"),
            resources.GetString("cbMaxYear.Items159"),
            resources.GetString("cbMaxYear.Items160"),
            resources.GetString("cbMaxYear.Items161"),
            resources.GetString("cbMaxYear.Items162"),
            resources.GetString("cbMaxYear.Items163"),
            resources.GetString("cbMaxYear.Items164"),
            resources.GetString("cbMaxYear.Items165"),
            resources.GetString("cbMaxYear.Items166"),
            resources.GetString("cbMaxYear.Items167"),
            resources.GetString("cbMaxYear.Items168"),
            resources.GetString("cbMaxYear.Items169"),
            resources.GetString("cbMaxYear.Items170"),
            resources.GetString("cbMaxYear.Items171"),
            resources.GetString("cbMaxYear.Items172"),
            resources.GetString("cbMaxYear.Items173"),
            resources.GetString("cbMaxYear.Items174"),
            resources.GetString("cbMaxYear.Items175"),
            resources.GetString("cbMaxYear.Items176"),
            resources.GetString("cbMaxYear.Items177"),
            resources.GetString("cbMaxYear.Items178"),
            resources.GetString("cbMaxYear.Items179"),
            resources.GetString("cbMaxYear.Items180"),
            resources.GetString("cbMaxYear.Items181"),
            resources.GetString("cbMaxYear.Items182"),
            resources.GetString("cbMaxYear.Items183"),
            resources.GetString("cbMaxYear.Items184"),
            resources.GetString("cbMaxYear.Items185"),
            resources.GetString("cbMaxYear.Items186"),
            resources.GetString("cbMaxYear.Items187"),
            resources.GetString("cbMaxYear.Items188"),
            resources.GetString("cbMaxYear.Items189"),
            resources.GetString("cbMaxYear.Items190"),
            resources.GetString("cbMaxYear.Items191"),
            resources.GetString("cbMaxYear.Items192"),
            resources.GetString("cbMaxYear.Items193"),
            resources.GetString("cbMaxYear.Items194"),
            resources.GetString("cbMaxYear.Items195"),
            resources.GetString("cbMaxYear.Items196"),
            resources.GetString("cbMaxYear.Items197"),
            resources.GetString("cbMaxYear.Items198"),
            resources.GetString("cbMaxYear.Items199"),
            resources.GetString("cbMaxYear.Items200"),
            resources.GetString("cbMaxYear.Items201"),
            resources.GetString("cbMaxYear.Items202"),
            resources.GetString("cbMaxYear.Items203"),
            resources.GetString("cbMaxYear.Items204"),
            resources.GetString("cbMaxYear.Items205"),
            resources.GetString("cbMaxYear.Items206"),
            resources.GetString("cbMaxYear.Items207"),
            resources.GetString("cbMaxYear.Items208"),
            resources.GetString("cbMaxYear.Items209"),
            resources.GetString("cbMaxYear.Items210"),
            resources.GetString("cbMaxYear.Items211"),
            resources.GetString("cbMaxYear.Items212"),
            resources.GetString("cbMaxYear.Items213"),
            resources.GetString("cbMaxYear.Items214"),
            resources.GetString("cbMaxYear.Items215"),
            resources.GetString("cbMaxYear.Items216"),
            resources.GetString("cbMaxYear.Items217"),
            resources.GetString("cbMaxYear.Items218"),
            resources.GetString("cbMaxYear.Items219"),
            resources.GetString("cbMaxYear.Items220"),
            resources.GetString("cbMaxYear.Items221"),
            resources.GetString("cbMaxYear.Items222"),
            resources.GetString("cbMaxYear.Items223"),
            resources.GetString("cbMaxYear.Items224"),
            resources.GetString("cbMaxYear.Items225"),
            resources.GetString("cbMaxYear.Items226"),
            resources.GetString("cbMaxYear.Items227"),
            resources.GetString("cbMaxYear.Items228"),
            resources.GetString("cbMaxYear.Items229"),
            resources.GetString("cbMaxYear.Items230"),
            resources.GetString("cbMaxYear.Items231"),
            resources.GetString("cbMaxYear.Items232"),
            resources.GetString("cbMaxYear.Items233"),
            resources.GetString("cbMaxYear.Items234"),
            resources.GetString("cbMaxYear.Items235"),
            resources.GetString("cbMaxYear.Items236"),
            resources.GetString("cbMaxYear.Items237"),
            resources.GetString("cbMaxYear.Items238"),
            resources.GetString("cbMaxYear.Items239"),
            resources.GetString("cbMaxYear.Items240"),
            resources.GetString("cbMaxYear.Items241"),
            resources.GetString("cbMaxYear.Items242"),
            resources.GetString("cbMaxYear.Items243"),
            resources.GetString("cbMaxYear.Items244"),
            resources.GetString("cbMaxYear.Items245"),
            resources.GetString("cbMaxYear.Items246"),
            resources.GetString("cbMaxYear.Items247"),
            resources.GetString("cbMaxYear.Items248"),
            resources.GetString("cbMaxYear.Items249"),
            resources.GetString("cbMaxYear.Items250"),
            resources.GetString("cbMaxYear.Items251"),
            resources.GetString("cbMaxYear.Items252"),
            resources.GetString("cbMaxYear.Items253"),
            resources.GetString("cbMaxYear.Items254"),
            resources.GetString("cbMaxYear.Items255"),
            resources.GetString("cbMaxYear.Items256"),
            resources.GetString("cbMaxYear.Items257"),
            resources.GetString("cbMaxYear.Items258"),
            resources.GetString("cbMaxYear.Items259"),
            resources.GetString("cbMaxYear.Items260"),
            resources.GetString("cbMaxYear.Items261"),
            resources.GetString("cbMaxYear.Items262"),
            resources.GetString("cbMaxYear.Items263"),
            resources.GetString("cbMaxYear.Items264"),
            resources.GetString("cbMaxYear.Items265"),
            resources.GetString("cbMaxYear.Items266"),
            resources.GetString("cbMaxYear.Items267"),
            resources.GetString("cbMaxYear.Items268"),
            resources.GetString("cbMaxYear.Items269"),
            resources.GetString("cbMaxYear.Items270"),
            resources.GetString("cbMaxYear.Items271"),
            resources.GetString("cbMaxYear.Items272"),
            resources.GetString("cbMaxYear.Items273"),
            resources.GetString("cbMaxYear.Items274"),
            resources.GetString("cbMaxYear.Items275"),
            resources.GetString("cbMaxYear.Items276"),
            resources.GetString("cbMaxYear.Items277"),
            resources.GetString("cbMaxYear.Items278"),
            resources.GetString("cbMaxYear.Items279"),
            resources.GetString("cbMaxYear.Items280"),
            resources.GetString("cbMaxYear.Items281"),
            resources.GetString("cbMaxYear.Items282"),
            resources.GetString("cbMaxYear.Items283"),
            resources.GetString("cbMaxYear.Items284"),
            resources.GetString("cbMaxYear.Items285"),
            resources.GetString("cbMaxYear.Items286"),
            resources.GetString("cbMaxYear.Items287"),
            resources.GetString("cbMaxYear.Items288"),
            resources.GetString("cbMaxYear.Items289"),
            resources.GetString("cbMaxYear.Items290"),
            resources.GetString("cbMaxYear.Items291"),
            resources.GetString("cbMaxYear.Items292"),
            resources.GetString("cbMaxYear.Items293"),
            resources.GetString("cbMaxYear.Items294"),
            resources.GetString("cbMaxYear.Items295"),
            resources.GetString("cbMaxYear.Items296"),
            resources.GetString("cbMaxYear.Items297"),
            resources.GetString("cbMaxYear.Items298"),
            resources.GetString("cbMaxYear.Items299"),
            resources.GetString("cbMaxYear.Items300"),
            resources.GetString("cbMaxYear.Items301"),
            resources.GetString("cbMaxYear.Items302"),
            resources.GetString("cbMaxYear.Items303"),
            resources.GetString("cbMaxYear.Items304"),
            resources.GetString("cbMaxYear.Items305"),
            resources.GetString("cbMaxYear.Items306"),
            resources.GetString("cbMaxYear.Items307"),
            resources.GetString("cbMaxYear.Items308"),
            resources.GetString("cbMaxYear.Items309"),
            resources.GetString("cbMaxYear.Items310"),
            resources.GetString("cbMaxYear.Items311"),
            resources.GetString("cbMaxYear.Items312"),
            resources.GetString("cbMaxYear.Items313"),
            resources.GetString("cbMaxYear.Items314"),
            resources.GetString("cbMaxYear.Items315"),
            resources.GetString("cbMaxYear.Items316"),
            resources.GetString("cbMaxYear.Items317"),
            resources.GetString("cbMaxYear.Items318"),
            resources.GetString("cbMaxYear.Items319"),
            resources.GetString("cbMaxYear.Items320"),
            resources.GetString("cbMaxYear.Items321"),
            resources.GetString("cbMaxYear.Items322"),
            resources.GetString("cbMaxYear.Items323"),
            resources.GetString("cbMaxYear.Items324"),
            resources.GetString("cbMaxYear.Items325"),
            resources.GetString("cbMaxYear.Items326"),
            resources.GetString("cbMaxYear.Items327"),
            resources.GetString("cbMaxYear.Items328"),
            resources.GetString("cbMaxYear.Items329"),
            resources.GetString("cbMaxYear.Items330"),
            resources.GetString("cbMaxYear.Items331"),
            resources.GetString("cbMaxYear.Items332"),
            resources.GetString("cbMaxYear.Items333"),
            resources.GetString("cbMaxYear.Items334"),
            resources.GetString("cbMaxYear.Items335"),
            resources.GetString("cbMaxYear.Items336"),
            resources.GetString("cbMaxYear.Items337"),
            resources.GetString("cbMaxYear.Items338"),
            resources.GetString("cbMaxYear.Items339"),
            resources.GetString("cbMaxYear.Items340"),
            resources.GetString("cbMaxYear.Items341"),
            resources.GetString("cbMaxYear.Items342"),
            resources.GetString("cbMaxYear.Items343"),
            resources.GetString("cbMaxYear.Items344"),
            resources.GetString("cbMaxYear.Items345"),
            resources.GetString("cbMaxYear.Items346"),
            resources.GetString("cbMaxYear.Items347"),
            resources.GetString("cbMaxYear.Items348"),
            resources.GetString("cbMaxYear.Items349"),
            resources.GetString("cbMaxYear.Items350"),
            resources.GetString("cbMaxYear.Items351"),
            resources.GetString("cbMaxYear.Items352"),
            resources.GetString("cbMaxYear.Items353"),
            resources.GetString("cbMaxYear.Items354"),
            resources.GetString("cbMaxYear.Items355"),
            resources.GetString("cbMaxYear.Items356"),
            resources.GetString("cbMaxYear.Items357"),
            resources.GetString("cbMaxYear.Items358"),
            resources.GetString("cbMaxYear.Items359"),
            resources.GetString("cbMaxYear.Items360"),
            resources.GetString("cbMaxYear.Items361"),
            resources.GetString("cbMaxYear.Items362"),
            resources.GetString("cbMaxYear.Items363"),
            resources.GetString("cbMaxYear.Items364"),
            resources.GetString("cbMaxYear.Items365"),
            resources.GetString("cbMaxYear.Items366"),
            resources.GetString("cbMaxYear.Items367"),
            resources.GetString("cbMaxYear.Items368"),
            resources.GetString("cbMaxYear.Items369"),
            resources.GetString("cbMaxYear.Items370"),
            resources.GetString("cbMaxYear.Items371"),
            resources.GetString("cbMaxYear.Items372"),
            resources.GetString("cbMaxYear.Items373"),
            resources.GetString("cbMaxYear.Items374"),
            resources.GetString("cbMaxYear.Items375"),
            resources.GetString("cbMaxYear.Items376"),
            resources.GetString("cbMaxYear.Items377"),
            resources.GetString("cbMaxYear.Items378"),
            resources.GetString("cbMaxYear.Items379"),
            resources.GetString("cbMaxYear.Items380"),
            resources.GetString("cbMaxYear.Items381"),
            resources.GetString("cbMaxYear.Items382"),
            resources.GetString("cbMaxYear.Items383"),
            resources.GetString("cbMaxYear.Items384"),
            resources.GetString("cbMaxYear.Items385"),
            resources.GetString("cbMaxYear.Items386"),
            resources.GetString("cbMaxYear.Items387"),
            resources.GetString("cbMaxYear.Items388"),
            resources.GetString("cbMaxYear.Items389"),
            resources.GetString("cbMaxYear.Items390"),
            resources.GetString("cbMaxYear.Items391"),
            resources.GetString("cbMaxYear.Items392"),
            resources.GetString("cbMaxYear.Items393"),
            resources.GetString("cbMaxYear.Items394"),
            resources.GetString("cbMaxYear.Items395"),
            resources.GetString("cbMaxYear.Items396"),
            resources.GetString("cbMaxYear.Items397"),
            resources.GetString("cbMaxYear.Items398"),
            resources.GetString("cbMaxYear.Items399"),
            resources.GetString("cbMaxYear.Items400"),
            resources.GetString("cbMaxYear.Items401"),
            resources.GetString("cbMaxYear.Items402"),
            resources.GetString("cbMaxYear.Items403"),
            resources.GetString("cbMaxYear.Items404"),
            resources.GetString("cbMaxYear.Items405"),
            resources.GetString("cbMaxYear.Items406"),
            resources.GetString("cbMaxYear.Items407"),
            resources.GetString("cbMaxYear.Items408"),
            resources.GetString("cbMaxYear.Items409"),
            resources.GetString("cbMaxYear.Items410"),
            resources.GetString("cbMaxYear.Items411"),
            resources.GetString("cbMaxYear.Items412"),
            resources.GetString("cbMaxYear.Items413"),
            resources.GetString("cbMaxYear.Items414"),
            resources.GetString("cbMaxYear.Items415"),
            resources.GetString("cbMaxYear.Items416"),
            resources.GetString("cbMaxYear.Items417"),
            resources.GetString("cbMaxYear.Items418"),
            resources.GetString("cbMaxYear.Items419"),
            resources.GetString("cbMaxYear.Items420"),
            resources.GetString("cbMaxYear.Items421"),
            resources.GetString("cbMaxYear.Items422"),
            resources.GetString("cbMaxYear.Items423"),
            resources.GetString("cbMaxYear.Items424"),
            resources.GetString("cbMaxYear.Items425"),
            resources.GetString("cbMaxYear.Items426"),
            resources.GetString("cbMaxYear.Items427"),
            resources.GetString("cbMaxYear.Items428"),
            resources.GetString("cbMaxYear.Items429"),
            resources.GetString("cbMaxYear.Items430"),
            resources.GetString("cbMaxYear.Items431"),
            resources.GetString("cbMaxYear.Items432"),
            resources.GetString("cbMaxYear.Items433"),
            resources.GetString("cbMaxYear.Items434"),
            resources.GetString("cbMaxYear.Items435"),
            resources.GetString("cbMaxYear.Items436"),
            resources.GetString("cbMaxYear.Items437"),
            resources.GetString("cbMaxYear.Items438"),
            resources.GetString("cbMaxYear.Items439"),
            resources.GetString("cbMaxYear.Items440"),
            resources.GetString("cbMaxYear.Items441"),
            resources.GetString("cbMaxYear.Items442"),
            resources.GetString("cbMaxYear.Items443"),
            resources.GetString("cbMaxYear.Items444"),
            resources.GetString("cbMaxYear.Items445"),
            resources.GetString("cbMaxYear.Items446"),
            resources.GetString("cbMaxYear.Items447"),
            resources.GetString("cbMaxYear.Items448"),
            resources.GetString("cbMaxYear.Items449"),
            resources.GetString("cbMaxYear.Items450"),
            resources.GetString("cbMaxYear.Items451"),
            resources.GetString("cbMaxYear.Items452"),
            resources.GetString("cbMaxYear.Items453"),
            resources.GetString("cbMaxYear.Items454"),
            resources.GetString("cbMaxYear.Items455"),
            resources.GetString("cbMaxYear.Items456"),
            resources.GetString("cbMaxYear.Items457"),
            resources.GetString("cbMaxYear.Items458"),
            resources.GetString("cbMaxYear.Items459"),
            resources.GetString("cbMaxYear.Items460"),
            resources.GetString("cbMaxYear.Items461"),
            resources.GetString("cbMaxYear.Items462"),
            resources.GetString("cbMaxYear.Items463"),
            resources.GetString("cbMaxYear.Items464"),
            resources.GetString("cbMaxYear.Items465"),
            resources.GetString("cbMaxYear.Items466"),
            resources.GetString("cbMaxYear.Items467"),
            resources.GetString("cbMaxYear.Items468"),
            resources.GetString("cbMaxYear.Items469"),
            resources.GetString("cbMaxYear.Items470"),
            resources.GetString("cbMaxYear.Items471"),
            resources.GetString("cbMaxYear.Items472"),
            resources.GetString("cbMaxYear.Items473"),
            resources.GetString("cbMaxYear.Items474"),
            resources.GetString("cbMaxYear.Items475"),
            resources.GetString("cbMaxYear.Items476"),
            resources.GetString("cbMaxYear.Items477"),
            resources.GetString("cbMaxYear.Items478"),
            resources.GetString("cbMaxYear.Items479"),
            resources.GetString("cbMaxYear.Items480"),
            resources.GetString("cbMaxYear.Items481"),
            resources.GetString("cbMaxYear.Items482"),
            resources.GetString("cbMaxYear.Items483"),
            resources.GetString("cbMaxYear.Items484"),
            resources.GetString("cbMaxYear.Items485"),
            resources.GetString("cbMaxYear.Items486"),
            resources.GetString("cbMaxYear.Items487"),
            resources.GetString("cbMaxYear.Items488"),
            resources.GetString("cbMaxYear.Items489"),
            resources.GetString("cbMaxYear.Items490"),
            resources.GetString("cbMaxYear.Items491"),
            resources.GetString("cbMaxYear.Items492"),
            resources.GetString("cbMaxYear.Items493"),
            resources.GetString("cbMaxYear.Items494"),
            resources.GetString("cbMaxYear.Items495"),
            resources.GetString("cbMaxYear.Items496"),
            resources.GetString("cbMaxYear.Items497"),
            resources.GetString("cbMaxYear.Items498"),
            resources.GetString("cbMaxYear.Items499"),
            resources.GetString("cbMaxYear.Items500"),
            resources.GetString("cbMaxYear.Items501"),
            resources.GetString("cbMaxYear.Items502"),
            resources.GetString("cbMaxYear.Items503"),
            resources.GetString("cbMaxYear.Items504"),
            resources.GetString("cbMaxYear.Items505"),
            resources.GetString("cbMaxYear.Items506"),
            resources.GetString("cbMaxYear.Items507"),
            resources.GetString("cbMaxYear.Items508"),
            resources.GetString("cbMaxYear.Items509"),
            resources.GetString("cbMaxYear.Items510"),
            resources.GetString("cbMaxYear.Items511"),
            resources.GetString("cbMaxYear.Items512"),
            resources.GetString("cbMaxYear.Items513"),
            resources.GetString("cbMaxYear.Items514"),
            resources.GetString("cbMaxYear.Items515"),
            resources.GetString("cbMaxYear.Items516"),
            resources.GetString("cbMaxYear.Items517"),
            resources.GetString("cbMaxYear.Items518"),
            resources.GetString("cbMaxYear.Items519"),
            resources.GetString("cbMaxYear.Items520"),
            resources.GetString("cbMaxYear.Items521"),
            resources.GetString("cbMaxYear.Items522"),
            resources.GetString("cbMaxYear.Items523"),
            resources.GetString("cbMaxYear.Items524"),
            resources.GetString("cbMaxYear.Items525"),
            resources.GetString("cbMaxYear.Items526"),
            resources.GetString("cbMaxYear.Items527")});
            resources.ApplyResources(this.cbMaxYear, "cbMaxYear");
            this.cbMaxYear.Name = "cbMaxYear";
            this.cbMaxYear.SelectedIndexChanged += new System.EventHandler(this.cbMaxYear_SelectedIndexChanged);
            // 
            // cbMaxMonth
            // 
            this.cbMaxMonth.FormattingEnabled = true;
            this.cbMaxMonth.Items.AddRange(new object[] {
            resources.GetString("cbMaxMonth.Items"),
            resources.GetString("cbMaxMonth.Items1"),
            resources.GetString("cbMaxMonth.Items2"),
            resources.GetString("cbMaxMonth.Items3"),
            resources.GetString("cbMaxMonth.Items4"),
            resources.GetString("cbMaxMonth.Items5"),
            resources.GetString("cbMaxMonth.Items6"),
            resources.GetString("cbMaxMonth.Items7"),
            resources.GetString("cbMaxMonth.Items8"),
            resources.GetString("cbMaxMonth.Items9"),
            resources.GetString("cbMaxMonth.Items10"),
            resources.GetString("cbMaxMonth.Items11"),
            resources.GetString("cbMaxMonth.Items12")});
            resources.ApplyResources(this.cbMaxMonth, "cbMaxMonth");
            this.cbMaxMonth.Name = "cbMaxMonth";
            this.cbMaxMonth.SelectedIndexChanged += new System.EventHandler(this.cbMaxMonth_SelectedIndexChanged);
            // 
            // cbMinYear
            // 
            this.cbMinYear.FormattingEnabled = true;
            this.cbMinYear.Items.AddRange(new object[] {
            resources.GetString("cbMinYear.Items"),
            resources.GetString("cbMinYear.Items1"),
            resources.GetString("cbMinYear.Items2"),
            resources.GetString("cbMinYear.Items3"),
            resources.GetString("cbMinYear.Items4"),
            resources.GetString("cbMinYear.Items5"),
            resources.GetString("cbMinYear.Items6"),
            resources.GetString("cbMinYear.Items7"),
            resources.GetString("cbMinYear.Items8"),
            resources.GetString("cbMinYear.Items9"),
            resources.GetString("cbMinYear.Items10"),
            resources.GetString("cbMinYear.Items11"),
            resources.GetString("cbMinYear.Items12"),
            resources.GetString("cbMinYear.Items13"),
            resources.GetString("cbMinYear.Items14"),
            resources.GetString("cbMinYear.Items15"),
            resources.GetString("cbMinYear.Items16"),
            resources.GetString("cbMinYear.Items17"),
            resources.GetString("cbMinYear.Items18"),
            resources.GetString("cbMinYear.Items19"),
            resources.GetString("cbMinYear.Items20"),
            resources.GetString("cbMinYear.Items21"),
            resources.GetString("cbMinYear.Items22"),
            resources.GetString("cbMinYear.Items23"),
            resources.GetString("cbMinYear.Items24"),
            resources.GetString("cbMinYear.Items25"),
            resources.GetString("cbMinYear.Items26"),
            resources.GetString("cbMinYear.Items27"),
            resources.GetString("cbMinYear.Items28"),
            resources.GetString("cbMinYear.Items29"),
            resources.GetString("cbMinYear.Items30"),
            resources.GetString("cbMinYear.Items31"),
            resources.GetString("cbMinYear.Items32"),
            resources.GetString("cbMinYear.Items33"),
            resources.GetString("cbMinYear.Items34"),
            resources.GetString("cbMinYear.Items35"),
            resources.GetString("cbMinYear.Items36"),
            resources.GetString("cbMinYear.Items37"),
            resources.GetString("cbMinYear.Items38"),
            resources.GetString("cbMinYear.Items39"),
            resources.GetString("cbMinYear.Items40"),
            resources.GetString("cbMinYear.Items41"),
            resources.GetString("cbMinYear.Items42"),
            resources.GetString("cbMinYear.Items43"),
            resources.GetString("cbMinYear.Items44"),
            resources.GetString("cbMinYear.Items45"),
            resources.GetString("cbMinYear.Items46"),
            resources.GetString("cbMinYear.Items47"),
            resources.GetString("cbMinYear.Items48"),
            resources.GetString("cbMinYear.Items49"),
            resources.GetString("cbMinYear.Items50"),
            resources.GetString("cbMinYear.Items51"),
            resources.GetString("cbMinYear.Items52"),
            resources.GetString("cbMinYear.Items53"),
            resources.GetString("cbMinYear.Items54"),
            resources.GetString("cbMinYear.Items55"),
            resources.GetString("cbMinYear.Items56"),
            resources.GetString("cbMinYear.Items57"),
            resources.GetString("cbMinYear.Items58"),
            resources.GetString("cbMinYear.Items59"),
            resources.GetString("cbMinYear.Items60"),
            resources.GetString("cbMinYear.Items61"),
            resources.GetString("cbMinYear.Items62"),
            resources.GetString("cbMinYear.Items63"),
            resources.GetString("cbMinYear.Items64"),
            resources.GetString("cbMinYear.Items65"),
            resources.GetString("cbMinYear.Items66"),
            resources.GetString("cbMinYear.Items67"),
            resources.GetString("cbMinYear.Items68"),
            resources.GetString("cbMinYear.Items69"),
            resources.GetString("cbMinYear.Items70"),
            resources.GetString("cbMinYear.Items71"),
            resources.GetString("cbMinYear.Items72"),
            resources.GetString("cbMinYear.Items73"),
            resources.GetString("cbMinYear.Items74"),
            resources.GetString("cbMinYear.Items75"),
            resources.GetString("cbMinYear.Items76"),
            resources.GetString("cbMinYear.Items77"),
            resources.GetString("cbMinYear.Items78"),
            resources.GetString("cbMinYear.Items79"),
            resources.GetString("cbMinYear.Items80"),
            resources.GetString("cbMinYear.Items81"),
            resources.GetString("cbMinYear.Items82"),
            resources.GetString("cbMinYear.Items83"),
            resources.GetString("cbMinYear.Items84"),
            resources.GetString("cbMinYear.Items85"),
            resources.GetString("cbMinYear.Items86"),
            resources.GetString("cbMinYear.Items87"),
            resources.GetString("cbMinYear.Items88"),
            resources.GetString("cbMinYear.Items89"),
            resources.GetString("cbMinYear.Items90"),
            resources.GetString("cbMinYear.Items91"),
            resources.GetString("cbMinYear.Items92"),
            resources.GetString("cbMinYear.Items93"),
            resources.GetString("cbMinYear.Items94"),
            resources.GetString("cbMinYear.Items95"),
            resources.GetString("cbMinYear.Items96"),
            resources.GetString("cbMinYear.Items97"),
            resources.GetString("cbMinYear.Items98"),
            resources.GetString("cbMinYear.Items99"),
            resources.GetString("cbMinYear.Items100"),
            resources.GetString("cbMinYear.Items101"),
            resources.GetString("cbMinYear.Items102"),
            resources.GetString("cbMinYear.Items103"),
            resources.GetString("cbMinYear.Items104"),
            resources.GetString("cbMinYear.Items105"),
            resources.GetString("cbMinYear.Items106"),
            resources.GetString("cbMinYear.Items107"),
            resources.GetString("cbMinYear.Items108"),
            resources.GetString("cbMinYear.Items109"),
            resources.GetString("cbMinYear.Items110"),
            resources.GetString("cbMinYear.Items111"),
            resources.GetString("cbMinYear.Items112"),
            resources.GetString("cbMinYear.Items113"),
            resources.GetString("cbMinYear.Items114"),
            resources.GetString("cbMinYear.Items115"),
            resources.GetString("cbMinYear.Items116"),
            resources.GetString("cbMinYear.Items117"),
            resources.GetString("cbMinYear.Items118"),
            resources.GetString("cbMinYear.Items119"),
            resources.GetString("cbMinYear.Items120"),
            resources.GetString("cbMinYear.Items121"),
            resources.GetString("cbMinYear.Items122"),
            resources.GetString("cbMinYear.Items123"),
            resources.GetString("cbMinYear.Items124"),
            resources.GetString("cbMinYear.Items125"),
            resources.GetString("cbMinYear.Items126"),
            resources.GetString("cbMinYear.Items127"),
            resources.GetString("cbMinYear.Items128"),
            resources.GetString("cbMinYear.Items129"),
            resources.GetString("cbMinYear.Items130"),
            resources.GetString("cbMinYear.Items131"),
            resources.GetString("cbMinYear.Items132"),
            resources.GetString("cbMinYear.Items133"),
            resources.GetString("cbMinYear.Items134"),
            resources.GetString("cbMinYear.Items135"),
            resources.GetString("cbMinYear.Items136"),
            resources.GetString("cbMinYear.Items137"),
            resources.GetString("cbMinYear.Items138"),
            resources.GetString("cbMinYear.Items139"),
            resources.GetString("cbMinYear.Items140"),
            resources.GetString("cbMinYear.Items141"),
            resources.GetString("cbMinYear.Items142"),
            resources.GetString("cbMinYear.Items143"),
            resources.GetString("cbMinYear.Items144"),
            resources.GetString("cbMinYear.Items145"),
            resources.GetString("cbMinYear.Items146"),
            resources.GetString("cbMinYear.Items147"),
            resources.GetString("cbMinYear.Items148"),
            resources.GetString("cbMinYear.Items149"),
            resources.GetString("cbMinYear.Items150"),
            resources.GetString("cbMinYear.Items151"),
            resources.GetString("cbMinYear.Items152"),
            resources.GetString("cbMinYear.Items153"),
            resources.GetString("cbMinYear.Items154"),
            resources.GetString("cbMinYear.Items155"),
            resources.GetString("cbMinYear.Items156"),
            resources.GetString("cbMinYear.Items157"),
            resources.GetString("cbMinYear.Items158"),
            resources.GetString("cbMinYear.Items159"),
            resources.GetString("cbMinYear.Items160"),
            resources.GetString("cbMinYear.Items161"),
            resources.GetString("cbMinYear.Items162"),
            resources.GetString("cbMinYear.Items163"),
            resources.GetString("cbMinYear.Items164"),
            resources.GetString("cbMinYear.Items165"),
            resources.GetString("cbMinYear.Items166"),
            resources.GetString("cbMinYear.Items167"),
            resources.GetString("cbMinYear.Items168"),
            resources.GetString("cbMinYear.Items169"),
            resources.GetString("cbMinYear.Items170"),
            resources.GetString("cbMinYear.Items171"),
            resources.GetString("cbMinYear.Items172"),
            resources.GetString("cbMinYear.Items173"),
            resources.GetString("cbMinYear.Items174"),
            resources.GetString("cbMinYear.Items175"),
            resources.GetString("cbMinYear.Items176"),
            resources.GetString("cbMinYear.Items177"),
            resources.GetString("cbMinYear.Items178"),
            resources.GetString("cbMinYear.Items179"),
            resources.GetString("cbMinYear.Items180"),
            resources.GetString("cbMinYear.Items181"),
            resources.GetString("cbMinYear.Items182"),
            resources.GetString("cbMinYear.Items183"),
            resources.GetString("cbMinYear.Items184"),
            resources.GetString("cbMinYear.Items185"),
            resources.GetString("cbMinYear.Items186"),
            resources.GetString("cbMinYear.Items187"),
            resources.GetString("cbMinYear.Items188"),
            resources.GetString("cbMinYear.Items189"),
            resources.GetString("cbMinYear.Items190"),
            resources.GetString("cbMinYear.Items191"),
            resources.GetString("cbMinYear.Items192"),
            resources.GetString("cbMinYear.Items193"),
            resources.GetString("cbMinYear.Items194"),
            resources.GetString("cbMinYear.Items195"),
            resources.GetString("cbMinYear.Items196"),
            resources.GetString("cbMinYear.Items197"),
            resources.GetString("cbMinYear.Items198"),
            resources.GetString("cbMinYear.Items199"),
            resources.GetString("cbMinYear.Items200"),
            resources.GetString("cbMinYear.Items201"),
            resources.GetString("cbMinYear.Items202"),
            resources.GetString("cbMinYear.Items203"),
            resources.GetString("cbMinYear.Items204"),
            resources.GetString("cbMinYear.Items205"),
            resources.GetString("cbMinYear.Items206"),
            resources.GetString("cbMinYear.Items207"),
            resources.GetString("cbMinYear.Items208"),
            resources.GetString("cbMinYear.Items209"),
            resources.GetString("cbMinYear.Items210"),
            resources.GetString("cbMinYear.Items211"),
            resources.GetString("cbMinYear.Items212"),
            resources.GetString("cbMinYear.Items213"),
            resources.GetString("cbMinYear.Items214"),
            resources.GetString("cbMinYear.Items215"),
            resources.GetString("cbMinYear.Items216"),
            resources.GetString("cbMinYear.Items217"),
            resources.GetString("cbMinYear.Items218"),
            resources.GetString("cbMinYear.Items219"),
            resources.GetString("cbMinYear.Items220"),
            resources.GetString("cbMinYear.Items221"),
            resources.GetString("cbMinYear.Items222"),
            resources.GetString("cbMinYear.Items223"),
            resources.GetString("cbMinYear.Items224"),
            resources.GetString("cbMinYear.Items225"),
            resources.GetString("cbMinYear.Items226"),
            resources.GetString("cbMinYear.Items227"),
            resources.GetString("cbMinYear.Items228"),
            resources.GetString("cbMinYear.Items229"),
            resources.GetString("cbMinYear.Items230"),
            resources.GetString("cbMinYear.Items231"),
            resources.GetString("cbMinYear.Items232"),
            resources.GetString("cbMinYear.Items233"),
            resources.GetString("cbMinYear.Items234"),
            resources.GetString("cbMinYear.Items235"),
            resources.GetString("cbMinYear.Items236"),
            resources.GetString("cbMinYear.Items237"),
            resources.GetString("cbMinYear.Items238"),
            resources.GetString("cbMinYear.Items239"),
            resources.GetString("cbMinYear.Items240"),
            resources.GetString("cbMinYear.Items241"),
            resources.GetString("cbMinYear.Items242"),
            resources.GetString("cbMinYear.Items243"),
            resources.GetString("cbMinYear.Items244"),
            resources.GetString("cbMinYear.Items245"),
            resources.GetString("cbMinYear.Items246"),
            resources.GetString("cbMinYear.Items247"),
            resources.GetString("cbMinYear.Items248"),
            resources.GetString("cbMinYear.Items249"),
            resources.GetString("cbMinYear.Items250"),
            resources.GetString("cbMinYear.Items251"),
            resources.GetString("cbMinYear.Items252"),
            resources.GetString("cbMinYear.Items253"),
            resources.GetString("cbMinYear.Items254"),
            resources.GetString("cbMinYear.Items255"),
            resources.GetString("cbMinYear.Items256"),
            resources.GetString("cbMinYear.Items257"),
            resources.GetString("cbMinYear.Items258"),
            resources.GetString("cbMinYear.Items259"),
            resources.GetString("cbMinYear.Items260"),
            resources.GetString("cbMinYear.Items261"),
            resources.GetString("cbMinYear.Items262"),
            resources.GetString("cbMinYear.Items263"),
            resources.GetString("cbMinYear.Items264"),
            resources.GetString("cbMinYear.Items265"),
            resources.GetString("cbMinYear.Items266"),
            resources.GetString("cbMinYear.Items267"),
            resources.GetString("cbMinYear.Items268"),
            resources.GetString("cbMinYear.Items269"),
            resources.GetString("cbMinYear.Items270"),
            resources.GetString("cbMinYear.Items271"),
            resources.GetString("cbMinYear.Items272"),
            resources.GetString("cbMinYear.Items273"),
            resources.GetString("cbMinYear.Items274"),
            resources.GetString("cbMinYear.Items275"),
            resources.GetString("cbMinYear.Items276"),
            resources.GetString("cbMinYear.Items277"),
            resources.GetString("cbMinYear.Items278"),
            resources.GetString("cbMinYear.Items279"),
            resources.GetString("cbMinYear.Items280"),
            resources.GetString("cbMinYear.Items281"),
            resources.GetString("cbMinYear.Items282"),
            resources.GetString("cbMinYear.Items283"),
            resources.GetString("cbMinYear.Items284"),
            resources.GetString("cbMinYear.Items285"),
            resources.GetString("cbMinYear.Items286"),
            resources.GetString("cbMinYear.Items287"),
            resources.GetString("cbMinYear.Items288"),
            resources.GetString("cbMinYear.Items289"),
            resources.GetString("cbMinYear.Items290"),
            resources.GetString("cbMinYear.Items291"),
            resources.GetString("cbMinYear.Items292"),
            resources.GetString("cbMinYear.Items293"),
            resources.GetString("cbMinYear.Items294"),
            resources.GetString("cbMinYear.Items295"),
            resources.GetString("cbMinYear.Items296"),
            resources.GetString("cbMinYear.Items297"),
            resources.GetString("cbMinYear.Items298"),
            resources.GetString("cbMinYear.Items299"),
            resources.GetString("cbMinYear.Items300"),
            resources.GetString("cbMinYear.Items301"),
            resources.GetString("cbMinYear.Items302"),
            resources.GetString("cbMinYear.Items303"),
            resources.GetString("cbMinYear.Items304"),
            resources.GetString("cbMinYear.Items305"),
            resources.GetString("cbMinYear.Items306"),
            resources.GetString("cbMinYear.Items307"),
            resources.GetString("cbMinYear.Items308"),
            resources.GetString("cbMinYear.Items309"),
            resources.GetString("cbMinYear.Items310"),
            resources.GetString("cbMinYear.Items311"),
            resources.GetString("cbMinYear.Items312"),
            resources.GetString("cbMinYear.Items313"),
            resources.GetString("cbMinYear.Items314"),
            resources.GetString("cbMinYear.Items315"),
            resources.GetString("cbMinYear.Items316"),
            resources.GetString("cbMinYear.Items317"),
            resources.GetString("cbMinYear.Items318"),
            resources.GetString("cbMinYear.Items319"),
            resources.GetString("cbMinYear.Items320"),
            resources.GetString("cbMinYear.Items321"),
            resources.GetString("cbMinYear.Items322"),
            resources.GetString("cbMinYear.Items323"),
            resources.GetString("cbMinYear.Items324"),
            resources.GetString("cbMinYear.Items325"),
            resources.GetString("cbMinYear.Items326"),
            resources.GetString("cbMinYear.Items327"),
            resources.GetString("cbMinYear.Items328"),
            resources.GetString("cbMinYear.Items329"),
            resources.GetString("cbMinYear.Items330"),
            resources.GetString("cbMinYear.Items331"),
            resources.GetString("cbMinYear.Items332"),
            resources.GetString("cbMinYear.Items333"),
            resources.GetString("cbMinYear.Items334"),
            resources.GetString("cbMinYear.Items335"),
            resources.GetString("cbMinYear.Items336"),
            resources.GetString("cbMinYear.Items337"),
            resources.GetString("cbMinYear.Items338"),
            resources.GetString("cbMinYear.Items339"),
            resources.GetString("cbMinYear.Items340"),
            resources.GetString("cbMinYear.Items341"),
            resources.GetString("cbMinYear.Items342"),
            resources.GetString("cbMinYear.Items343"),
            resources.GetString("cbMinYear.Items344"),
            resources.GetString("cbMinYear.Items345"),
            resources.GetString("cbMinYear.Items346"),
            resources.GetString("cbMinYear.Items347"),
            resources.GetString("cbMinYear.Items348"),
            resources.GetString("cbMinYear.Items349"),
            resources.GetString("cbMinYear.Items350"),
            resources.GetString("cbMinYear.Items351"),
            resources.GetString("cbMinYear.Items352"),
            resources.GetString("cbMinYear.Items353"),
            resources.GetString("cbMinYear.Items354"),
            resources.GetString("cbMinYear.Items355"),
            resources.GetString("cbMinYear.Items356"),
            resources.GetString("cbMinYear.Items357"),
            resources.GetString("cbMinYear.Items358"),
            resources.GetString("cbMinYear.Items359"),
            resources.GetString("cbMinYear.Items360"),
            resources.GetString("cbMinYear.Items361"),
            resources.GetString("cbMinYear.Items362"),
            resources.GetString("cbMinYear.Items363"),
            resources.GetString("cbMinYear.Items364"),
            resources.GetString("cbMinYear.Items365"),
            resources.GetString("cbMinYear.Items366"),
            resources.GetString("cbMinYear.Items367"),
            resources.GetString("cbMinYear.Items368"),
            resources.GetString("cbMinYear.Items369"),
            resources.GetString("cbMinYear.Items370"),
            resources.GetString("cbMinYear.Items371"),
            resources.GetString("cbMinYear.Items372"),
            resources.GetString("cbMinYear.Items373"),
            resources.GetString("cbMinYear.Items374"),
            resources.GetString("cbMinYear.Items375"),
            resources.GetString("cbMinYear.Items376"),
            resources.GetString("cbMinYear.Items377"),
            resources.GetString("cbMinYear.Items378"),
            resources.GetString("cbMinYear.Items379"),
            resources.GetString("cbMinYear.Items380"),
            resources.GetString("cbMinYear.Items381"),
            resources.GetString("cbMinYear.Items382"),
            resources.GetString("cbMinYear.Items383"),
            resources.GetString("cbMinYear.Items384"),
            resources.GetString("cbMinYear.Items385"),
            resources.GetString("cbMinYear.Items386"),
            resources.GetString("cbMinYear.Items387"),
            resources.GetString("cbMinYear.Items388"),
            resources.GetString("cbMinYear.Items389"),
            resources.GetString("cbMinYear.Items390"),
            resources.GetString("cbMinYear.Items391"),
            resources.GetString("cbMinYear.Items392"),
            resources.GetString("cbMinYear.Items393"),
            resources.GetString("cbMinYear.Items394"),
            resources.GetString("cbMinYear.Items395"),
            resources.GetString("cbMinYear.Items396"),
            resources.GetString("cbMinYear.Items397"),
            resources.GetString("cbMinYear.Items398"),
            resources.GetString("cbMinYear.Items399"),
            resources.GetString("cbMinYear.Items400"),
            resources.GetString("cbMinYear.Items401"),
            resources.GetString("cbMinYear.Items402"),
            resources.GetString("cbMinYear.Items403"),
            resources.GetString("cbMinYear.Items404"),
            resources.GetString("cbMinYear.Items405"),
            resources.GetString("cbMinYear.Items406"),
            resources.GetString("cbMinYear.Items407"),
            resources.GetString("cbMinYear.Items408"),
            resources.GetString("cbMinYear.Items409"),
            resources.GetString("cbMinYear.Items410"),
            resources.GetString("cbMinYear.Items411"),
            resources.GetString("cbMinYear.Items412"),
            resources.GetString("cbMinYear.Items413"),
            resources.GetString("cbMinYear.Items414"),
            resources.GetString("cbMinYear.Items415"),
            resources.GetString("cbMinYear.Items416"),
            resources.GetString("cbMinYear.Items417"),
            resources.GetString("cbMinYear.Items418"),
            resources.GetString("cbMinYear.Items419"),
            resources.GetString("cbMinYear.Items420"),
            resources.GetString("cbMinYear.Items421"),
            resources.GetString("cbMinYear.Items422"),
            resources.GetString("cbMinYear.Items423"),
            resources.GetString("cbMinYear.Items424"),
            resources.GetString("cbMinYear.Items425"),
            resources.GetString("cbMinYear.Items426"),
            resources.GetString("cbMinYear.Items427"),
            resources.GetString("cbMinYear.Items428"),
            resources.GetString("cbMinYear.Items429"),
            resources.GetString("cbMinYear.Items430"),
            resources.GetString("cbMinYear.Items431"),
            resources.GetString("cbMinYear.Items432"),
            resources.GetString("cbMinYear.Items433"),
            resources.GetString("cbMinYear.Items434"),
            resources.GetString("cbMinYear.Items435"),
            resources.GetString("cbMinYear.Items436"),
            resources.GetString("cbMinYear.Items437"),
            resources.GetString("cbMinYear.Items438"),
            resources.GetString("cbMinYear.Items439"),
            resources.GetString("cbMinYear.Items440"),
            resources.GetString("cbMinYear.Items441"),
            resources.GetString("cbMinYear.Items442"),
            resources.GetString("cbMinYear.Items443"),
            resources.GetString("cbMinYear.Items444"),
            resources.GetString("cbMinYear.Items445"),
            resources.GetString("cbMinYear.Items446"),
            resources.GetString("cbMinYear.Items447"),
            resources.GetString("cbMinYear.Items448"),
            resources.GetString("cbMinYear.Items449"),
            resources.GetString("cbMinYear.Items450"),
            resources.GetString("cbMinYear.Items451"),
            resources.GetString("cbMinYear.Items452"),
            resources.GetString("cbMinYear.Items453"),
            resources.GetString("cbMinYear.Items454"),
            resources.GetString("cbMinYear.Items455"),
            resources.GetString("cbMinYear.Items456"),
            resources.GetString("cbMinYear.Items457"),
            resources.GetString("cbMinYear.Items458"),
            resources.GetString("cbMinYear.Items459"),
            resources.GetString("cbMinYear.Items460"),
            resources.GetString("cbMinYear.Items461"),
            resources.GetString("cbMinYear.Items462"),
            resources.GetString("cbMinYear.Items463"),
            resources.GetString("cbMinYear.Items464"),
            resources.GetString("cbMinYear.Items465"),
            resources.GetString("cbMinYear.Items466"),
            resources.GetString("cbMinYear.Items467"),
            resources.GetString("cbMinYear.Items468"),
            resources.GetString("cbMinYear.Items469"),
            resources.GetString("cbMinYear.Items470"),
            resources.GetString("cbMinYear.Items471"),
            resources.GetString("cbMinYear.Items472"),
            resources.GetString("cbMinYear.Items473"),
            resources.GetString("cbMinYear.Items474"),
            resources.GetString("cbMinYear.Items475"),
            resources.GetString("cbMinYear.Items476"),
            resources.GetString("cbMinYear.Items477"),
            resources.GetString("cbMinYear.Items478"),
            resources.GetString("cbMinYear.Items479"),
            resources.GetString("cbMinYear.Items480"),
            resources.GetString("cbMinYear.Items481"),
            resources.GetString("cbMinYear.Items482"),
            resources.GetString("cbMinYear.Items483"),
            resources.GetString("cbMinYear.Items484"),
            resources.GetString("cbMinYear.Items485"),
            resources.GetString("cbMinYear.Items486"),
            resources.GetString("cbMinYear.Items487"),
            resources.GetString("cbMinYear.Items488"),
            resources.GetString("cbMinYear.Items489"),
            resources.GetString("cbMinYear.Items490"),
            resources.GetString("cbMinYear.Items491"),
            resources.GetString("cbMinYear.Items492"),
            resources.GetString("cbMinYear.Items493"),
            resources.GetString("cbMinYear.Items494"),
            resources.GetString("cbMinYear.Items495"),
            resources.GetString("cbMinYear.Items496"),
            resources.GetString("cbMinYear.Items497"),
            resources.GetString("cbMinYear.Items498"),
            resources.GetString("cbMinYear.Items499"),
            resources.GetString("cbMinYear.Items500"),
            resources.GetString("cbMinYear.Items501"),
            resources.GetString("cbMinYear.Items502"),
            resources.GetString("cbMinYear.Items503"),
            resources.GetString("cbMinYear.Items504"),
            resources.GetString("cbMinYear.Items505"),
            resources.GetString("cbMinYear.Items506"),
            resources.GetString("cbMinYear.Items507"),
            resources.GetString("cbMinYear.Items508"),
            resources.GetString("cbMinYear.Items509"),
            resources.GetString("cbMinYear.Items510"),
            resources.GetString("cbMinYear.Items511"),
            resources.GetString("cbMinYear.Items512"),
            resources.GetString("cbMinYear.Items513"),
            resources.GetString("cbMinYear.Items514"),
            resources.GetString("cbMinYear.Items515"),
            resources.GetString("cbMinYear.Items516"),
            resources.GetString("cbMinYear.Items517"),
            resources.GetString("cbMinYear.Items518"),
            resources.GetString("cbMinYear.Items519"),
            resources.GetString("cbMinYear.Items520"),
            resources.GetString("cbMinYear.Items521"),
            resources.GetString("cbMinYear.Items522"),
            resources.GetString("cbMinYear.Items523"),
            resources.GetString("cbMinYear.Items524"),
            resources.GetString("cbMinYear.Items525"),
            resources.GetString("cbMinYear.Items526"),
            resources.GetString("cbMinYear.Items527")});
            resources.ApplyResources(this.cbMinYear, "cbMinYear");
            this.cbMinYear.Name = "cbMinYear";
            this.cbMinYear.SelectedIndexChanged += new System.EventHandler(this.cbMinYear_SelectedIndexChanged);
            // 
            // cbMinMonth
            // 
            this.cbMinMonth.FormattingEnabled = true;
            this.cbMinMonth.Items.AddRange(new object[] {
            resources.GetString("cbMinMonth.Items"),
            resources.GetString("cbMinMonth.Items1"),
            resources.GetString("cbMinMonth.Items2"),
            resources.GetString("cbMinMonth.Items3"),
            resources.GetString("cbMinMonth.Items4"),
            resources.GetString("cbMinMonth.Items5"),
            resources.GetString("cbMinMonth.Items6"),
            resources.GetString("cbMinMonth.Items7"),
            resources.GetString("cbMinMonth.Items8"),
            resources.GetString("cbMinMonth.Items9"),
            resources.GetString("cbMinMonth.Items10"),
            resources.GetString("cbMinMonth.Items11"),
            resources.GetString("cbMinMonth.Items12")});
            resources.ApplyResources(this.cbMinMonth, "cbMinMonth");
            this.cbMinMonth.Name = "cbMinMonth";
            this.cbMinMonth.SelectedIndexChanged += new System.EventHandler(this.cbMinMonth_SelectedIndexChanged);
            // 
            // pnlProgress
            // 
            this.pnlProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProgress.Controls.Add(this.lblArchive);
            this.pnlProgress.Controls.Add(this.lblProgress);
            this.pnlProgress.Controls.Add(this.lblProgressTitle);
            resources.ApplyResources(this.pnlProgress, "pnlProgress");
            this.pnlProgress.Name = "pnlProgress";
            // 
            // lblArchive
            // 
            resources.ApplyResources(this.lblArchive, "lblArchive");
            this.lblArchive.Name = "lblArchive";
            // 
            // lblProgress
            // 
            resources.ApplyResources(this.lblProgress, "lblProgress");
            this.lblProgress.Name = "lblProgress";
            // 
            // lblProgressTitle
            // 
            resources.ApplyResources(this.lblProgressTitle, "lblProgressTitle");
            this.lblProgressTitle.Name = "lblProgressTitle";
            // 
            // fmTable
            // 
            this.fmTable.AllowUserToAddRows = false;
            this.fmTable.AllowUserToDeleteRows = false;
            this.fmTable.AllowUserToOrderColumns = true;
            this.fmTable.AllowUserToResizeRows = false;
            resources.ApplyResources(this.fmTable, "fmTable");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.fmTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.fmTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fmTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ArchiveOrDir,
            this.ArchiveSize,
            this.TitleHeading,
            this.Rating_,
            this.Finished_,
            this.ReleaseDate_,
            this.LstPlayed,
            this.Cmnt,
            this.NoMod,
            this.Ins});
            this.fmTable.ContextMenuStrip = this.rightClickFM;
            this.fmTable.MultiSelect = false;
            this.fmTable.Name = "fmTable";
            this.fmTable.RowHeadersVisible = false;
            this.fmTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fmTable.StandardTab = true;
            this.fmTable.VirtualMode = true;
            this.fmTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fmTable_CellDoubleClick);
            this.fmTable.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.fmTable_CellToolTipTextNeeded);
            this.fmTable.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.fmTable_CellValueNeeded);
            this.fmTable.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.fmTable_ColumnHeaderMouseClick);
            this.fmTable.SelectionChanged += new System.EventHandler(this.fmTable_SelectionChanged);
            this.fmTable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fmTable_MouseDown);
            this.fmTable.MouseEnter += new System.EventHandler(this.fmTable_MouseEnter);
            // 
            // ArchiveOrDir
            // 
            resources.ApplyResources(this.ArchiveOrDir, "ArchiveOrDir");
            this.ArchiveOrDir.Name = "ArchiveOrDir";
            this.ArchiveOrDir.ReadOnly = true;
            // 
            // ArchiveSize
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ArchiveSize.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.ArchiveSize, "ArchiveSize");
            this.ArchiveSize.Name = "ArchiveSize";
            this.ArchiveSize.ReadOnly = true;
            this.ArchiveSize.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // TitleHeading
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TitleHeading.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.TitleHeading, "TitleHeading");
            this.TitleHeading.Name = "TitleHeading";
            this.TitleHeading.ReadOnly = true;
            // 
            // Rating_
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Rating_.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.Rating_, "Rating_");
            this.Rating_.Name = "Rating_";
            this.Rating_.ReadOnly = true;
            // 
            // Finished_
            // 
            resources.ApplyResources(this.Finished_, "Finished_");
            this.Finished_.Name = "Finished_";
            this.Finished_.ReadOnly = true;
            this.Finished_.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ReleaseDate_
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ReleaseDate_.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.ReleaseDate_, "ReleaseDate_");
            this.ReleaseDate_.Name = "ReleaseDate_";
            this.ReleaseDate_.ReadOnly = true;
            // 
            // LstPlayed
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LstPlayed.DefaultCellStyle = dataGridViewCellStyle6;
            resources.ApplyResources(this.LstPlayed, "LstPlayed");
            this.LstPlayed.Name = "LstPlayed";
            this.LstPlayed.ReadOnly = true;
            // 
            // Cmnt
            // 
            resources.ApplyResources(this.Cmnt, "Cmnt");
            this.Cmnt.Name = "Cmnt";
            this.Cmnt.ReadOnly = true;
            // 
            // NoMod
            // 
            resources.ApplyResources(this.NoMod, "NoMod");
            this.NoMod.Name = "NoMod";
            // 
            // Ins
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Ins.DefaultCellStyle = dataGridViewCellStyle7;
            resources.ApplyResources(this.Ins, "Ins");
            this.Ins.Name = "Ins";
            this.Ins.ReadOnly = true;
            // 
            // rightClickFM
            // 
            this.rightClickFM.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.rightClickFM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editFMDetailsToolStripMenuItem,
            this.scanAllFMsToolStripMenuItem,
            this.rescanThisFMToolStripMenuItem,
            this.generateFMiniToolStripMenuItem});
            this.rightClickFM.Name = "rightClickFM";
            resources.ApplyResources(this.rightClickFM, "rightClickFM");
            // 
            // editFMDetailsToolStripMenuItem
            // 
            this.editFMDetailsToolStripMenuItem.Name = "editFMDetailsToolStripMenuItem";
            resources.ApplyResources(this.editFMDetailsToolStripMenuItem, "editFMDetailsToolStripMenuItem");
            this.editFMDetailsToolStripMenuItem.Click += new System.EventHandler(this.editFMDetails_Click);
            // 
            // scanAllFMsToolStripMenuItem
            // 
            this.scanAllFMsToolStripMenuItem.Name = "scanAllFMsToolStripMenuItem";
            resources.ApplyResources(this.scanAllFMsToolStripMenuItem, "scanAllFMsToolStripMenuItem");
            this.scanAllFMsToolStripMenuItem.Click += new System.EventHandler(this.scanAllFMsToolStripMenuItem_Click);
            // 
            // rescanThisFMToolStripMenuItem
            // 
            this.rescanThisFMToolStripMenuItem.Name = "rescanThisFMToolStripMenuItem";
            resources.ApplyResources(this.rescanThisFMToolStripMenuItem, "rescanThisFMToolStripMenuItem");
            this.rescanThisFMToolStripMenuItem.Click += new System.EventHandler(this.rescanThisFMToolStripMenuItem_Click);
            // 
            // generateFMiniToolStripMenuItem
            // 
            this.generateFMiniToolStripMenuItem.Name = "generateFMiniToolStripMenuItem";
            resources.ApplyResources(this.generateFMiniToolStripMenuItem, "generateFMiniToolStripMenuItem");
            this.generateFMiniToolStripMenuItem.Click += new System.EventHandler(this.generateFMiniToolStripMenuItem_Click);
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Image = global::NewDarkLoader.Properties.Resources.refresh;
            this.btnRefresh.Name = "btnRefresh";
            this.toolTip1.SetToolTip(this.btnRefresh, resources.GetString("btnRefresh.ToolTip"));
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnHideTags
            // 
            resources.ApplyResources(this.btnHideTags, "btnHideTags");
            this.btnHideTags.Name = "btnHideTags";
            this.toolTip1.SetToolTip(this.btnHideTags, resources.GetString("btnHideTags.ToolTip"));
            this.btnHideTags.UseVisualStyleBackColor = true;
            this.btnHideTags.Click += new System.EventHandler(this.btnHideTags_Click);
            // 
            // gbTags
            // 
            resources.ApplyResources(this.gbTags, "gbTags");
            this.gbTags.Controls.Add(this.btnTagPresets);
            this.gbTags.Controls.Add(this.lbTags);
            this.gbTags.Controls.Add(this.lblFMTags);
            this.gbTags.Controls.Add(this.btnRemoveTags);
            this.gbTags.Controls.Add(this.tagTree);
            this.gbTags.Controls.Add(this.btnAddNewTag);
            this.gbTags.Controls.Add(this.tbAddTag);
            this.gbTags.Controls.Add(this.btnAddExistTag);
            this.gbTags.Controls.Add(this.menuTags);
            this.gbTags.Name = "gbTags";
            this.gbTags.TabStop = false;
            // 
            // btnTagPresets
            // 
            resources.ApplyResources(this.btnTagPresets, "btnTagPresets");
            this.btnTagPresets.Name = "btnTagPresets";
            this.btnTagPresets.UseVisualStyleBackColor = true;
            this.btnTagPresets.Click += new System.EventHandler(this.btnTagPresets_Click);
            // 
            // lbTags
            // 
            this.lbTags.FormattingEnabled = true;
            resources.ApplyResources(this.lbTags, "lbTags");
            this.lbTags.Name = "lbTags";
            this.lbTags.SelectedIndexChanged += new System.EventHandler(this.lbTags_SelectedIndexChanged);
            this.lbTags.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbTags_KeyDown);
            // 
            // lblFMTags
            // 
            resources.ApplyResources(this.lblFMTags, "lblFMTags");
            this.lblFMTags.Name = "lblFMTags";
            // 
            // btnRemoveTags
            // 
            resources.ApplyResources(this.btnRemoveTags, "btnRemoveTags");
            this.btnRemoveTags.Name = "btnRemoveTags";
            this.btnRemoveTags.UseVisualStyleBackColor = true;
            this.btnRemoveTags.Click += new System.EventHandler(this.btnRemoveTags_Click);
            // 
            // tagTree
            // 
            resources.ApplyResources(this.tagTree, "tagTree");
            this.tagTree.Name = "tagTree";
            this.tagTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tagTree_KeyDown);
            this.tagTree.MouseEnter += new System.EventHandler(this.tagTree_MouseEnter);
            // 
            // btnAddNewTag
            // 
            resources.ApplyResources(this.btnAddNewTag, "btnAddNewTag");
            this.btnAddNewTag.Name = "btnAddNewTag";
            this.btnAddNewTag.UseVisualStyleBackColor = true;
            this.btnAddNewTag.Click += new System.EventHandler(this.btnAddTag_Click);
            // 
            // tbAddTag
            // 
            resources.ApplyResources(this.tbAddTag, "tbAddTag");
            this.tbAddTag.Name = "tbAddTag";
            this.tbAddTag.TextChanged += new System.EventHandler(this.tbAddTag_TextChanged);
            // 
            // btnAddExistTag
            // 
            resources.ApplyResources(this.btnAddExistTag, "btnAddExistTag");
            this.btnAddExistTag.Name = "btnAddExistTag";
            this.btnAddExistTag.UseVisualStyleBackColor = true;
            this.btnAddExistTag.Click += new System.EventHandler(this.btnAddExistTag_Click);
            // 
            // menuTags
            // 
            resources.ApplyResources(this.menuTags, "menuTags");
            this.menuTags.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuTags.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tagPresetToolStripMenuItem});
            this.menuTags.Name = "menuTags";
            this.menuTags.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // tagPresetToolStripMenuItem
            // 
            this.tagPresetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authorToolStripMenuItem,
            this.contestToolStripMenuItem,
            this.genreToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.seriesToolStripMenuItem,
            this.campaignToolStripMenuItem,
            this.demoToolStripMenuItem,
            this.otherProtagonistToolStripMenuItem,
            this.unknownAuthorToolStripMenuItem});
            this.tagPresetToolStripMenuItem.Name = "tagPresetToolStripMenuItem";
            this.tagPresetToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            resources.ApplyResources(this.tagPresetToolStripMenuItem, "tagPresetToolStripMenuItem");
            // 
            // authorToolStripMenuItem
            // 
            this.authorToolStripMenuItem.Name = "authorToolStripMenuItem";
            resources.ApplyResources(this.authorToolStripMenuItem, "authorToolStripMenuItem");
            this.authorToolStripMenuItem.Click += new System.EventHandler(this.authorToolStripMenuItem_Click);
            // 
            // contestToolStripMenuItem
            // 
            this.contestToolStripMenuItem.Name = "contestToolStripMenuItem";
            resources.ApplyResources(this.contestToolStripMenuItem, "contestToolStripMenuItem");
            this.contestToolStripMenuItem.Click += new System.EventHandler(this.contestToolStripMenuItem_Click);
            // 
            // genreToolStripMenuItem
            // 
            this.genreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customToolStripMenuItem,
            this.actionToolStripMenuItem,
            this.crimeToolStripMenuItem,
            this.horrorToolStripMenuItem,
            this.mysteryToolStripMenuItem,
            this.puzzleToolStripMenuItem});
            this.genreToolStripMenuItem.Name = "genreToolStripMenuItem";
            resources.ApplyResources(this.genreToolStripMenuItem, "genreToolStripMenuItem");
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            resources.ApplyResources(this.customToolStripMenuItem, "customToolStripMenuItem");
            this.customToolStripMenuItem.Click += new System.EventHandler(this.customToolStripMenuItem_Click);
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            resources.ApplyResources(this.actionToolStripMenuItem, "actionToolStripMenuItem");
            this.actionToolStripMenuItem.Click += new System.EventHandler(this.actionToolStripMenuItem_Click);
            // 
            // crimeToolStripMenuItem
            // 
            this.crimeToolStripMenuItem.Name = "crimeToolStripMenuItem";
            resources.ApplyResources(this.crimeToolStripMenuItem, "crimeToolStripMenuItem");
            this.crimeToolStripMenuItem.Click += new System.EventHandler(this.crimeToolStripMenuItem_Click);
            // 
            // horrorToolStripMenuItem
            // 
            this.horrorToolStripMenuItem.Name = "horrorToolStripMenuItem";
            resources.ApplyResources(this.horrorToolStripMenuItem, "horrorToolStripMenuItem");
            this.horrorToolStripMenuItem.Click += new System.EventHandler(this.horrorToolStripMenuItem_Click);
            // 
            // mysteryToolStripMenuItem
            // 
            this.mysteryToolStripMenuItem.Name = "mysteryToolStripMenuItem";
            resources.ApplyResources(this.mysteryToolStripMenuItem, "mysteryToolStripMenuItem");
            this.mysteryToolStripMenuItem.Click += new System.EventHandler(this.mysteryToolStripMenuItem_Click);
            // 
            // puzzleToolStripMenuItem
            // 
            this.puzzleToolStripMenuItem.Name = "puzzleToolStripMenuItem";
            resources.ApplyResources(this.puzzleToolStripMenuItem, "puzzleToolStripMenuItem");
            this.puzzleToolStripMenuItem.Click += new System.EventHandler(this.puzzleToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customToolStripMenuItem1,
            this.englishToolStripMenuItem,
            this.czechToolStripMenuItem,
            this.dutchToolStripMenuItem,
            this.frenchToolStripMenuItem,
            this.germanToolStripMenuItem,
            this.hungarianToolStripMenuItem,
            this.italianToolStripMenuItem,
            this.japaneseToolStripMenuItem,
            this.polishToolStripMenuItem,
            this.russianToolStripMenuItem,
            this.spanishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // customToolStripMenuItem1
            // 
            this.customToolStripMenuItem1.Name = "customToolStripMenuItem1";
            resources.ApplyResources(this.customToolStripMenuItem1, "customToolStripMenuItem1");
            this.customToolStripMenuItem1.Click += new System.EventHandler(this.customToolStripMenuItem1_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // czechToolStripMenuItem
            // 
            this.czechToolStripMenuItem.Name = "czechToolStripMenuItem";
            resources.ApplyResources(this.czechToolStripMenuItem, "czechToolStripMenuItem");
            this.czechToolStripMenuItem.Click += new System.EventHandler(this.czechToolStripMenuItem_Click);
            // 
            // dutchToolStripMenuItem
            // 
            this.dutchToolStripMenuItem.Name = "dutchToolStripMenuItem";
            resources.ApplyResources(this.dutchToolStripMenuItem, "dutchToolStripMenuItem");
            this.dutchToolStripMenuItem.Click += new System.EventHandler(this.dutchToolStripMenuItem_Click);
            // 
            // frenchToolStripMenuItem
            // 
            this.frenchToolStripMenuItem.Name = "frenchToolStripMenuItem";
            resources.ApplyResources(this.frenchToolStripMenuItem, "frenchToolStripMenuItem");
            this.frenchToolStripMenuItem.Click += new System.EventHandler(this.frenchToolStripMenuItem_Click);
            // 
            // germanToolStripMenuItem
            // 
            this.germanToolStripMenuItem.Name = "germanToolStripMenuItem";
            resources.ApplyResources(this.germanToolStripMenuItem, "germanToolStripMenuItem");
            this.germanToolStripMenuItem.Click += new System.EventHandler(this.germanToolStripMenuItem_Click);
            // 
            // hungarianToolStripMenuItem
            // 
            this.hungarianToolStripMenuItem.Name = "hungarianToolStripMenuItem";
            resources.ApplyResources(this.hungarianToolStripMenuItem, "hungarianToolStripMenuItem");
            this.hungarianToolStripMenuItem.Click += new System.EventHandler(this.hugarianToolStripMenuItem_Click);
            // 
            // italianToolStripMenuItem
            // 
            this.italianToolStripMenuItem.Name = "italianToolStripMenuItem";
            resources.ApplyResources(this.italianToolStripMenuItem, "italianToolStripMenuItem");
            this.italianToolStripMenuItem.Click += new System.EventHandler(this.italianToolStripMenuItem_Click);
            // 
            // japaneseToolStripMenuItem
            // 
            this.japaneseToolStripMenuItem.Name = "japaneseToolStripMenuItem";
            resources.ApplyResources(this.japaneseToolStripMenuItem, "japaneseToolStripMenuItem");
            this.japaneseToolStripMenuItem.Click += new System.EventHandler(this.japaneseToolStripMenuItem_Click);
            // 
            // polishToolStripMenuItem
            // 
            this.polishToolStripMenuItem.Name = "polishToolStripMenuItem";
            resources.ApplyResources(this.polishToolStripMenuItem, "polishToolStripMenuItem");
            this.polishToolStripMenuItem.Click += new System.EventHandler(this.polishToolStripMenuItem_Click);
            // 
            // russianToolStripMenuItem
            // 
            this.russianToolStripMenuItem.Name = "russianToolStripMenuItem";
            resources.ApplyResources(this.russianToolStripMenuItem, "russianToolStripMenuItem");
            this.russianToolStripMenuItem.Click += new System.EventHandler(this.russianToolStripMenuItem_Click);
            // 
            // spanishToolStripMenuItem
            // 
            this.spanishToolStripMenuItem.Name = "spanishToolStripMenuItem";
            resources.ApplyResources(this.spanishToolStripMenuItem, "spanishToolStripMenuItem");
            this.spanishToolStripMenuItem.Click += new System.EventHandler(this.spanishToolStripMenuItem_Click);
            // 
            // seriesToolStripMenuItem
            // 
            this.seriesToolStripMenuItem.Name = "seriesToolStripMenuItem";
            resources.ApplyResources(this.seriesToolStripMenuItem, "seriesToolStripMenuItem");
            this.seriesToolStripMenuItem.Click += new System.EventHandler(this.seriesToolStripMenuItem_Click);
            // 
            // campaignToolStripMenuItem
            // 
            this.campaignToolStripMenuItem.Name = "campaignToolStripMenuItem";
            resources.ApplyResources(this.campaignToolStripMenuItem, "campaignToolStripMenuItem");
            this.campaignToolStripMenuItem.Click += new System.EventHandler(this.cToolStripMenuItem_Click);
            // 
            // demoToolStripMenuItem
            // 
            this.demoToolStripMenuItem.Name = "demoToolStripMenuItem";
            resources.ApplyResources(this.demoToolStripMenuItem, "demoToolStripMenuItem");
            this.demoToolStripMenuItem.Click += new System.EventHandler(this.demoToolStripMenuItem_Click);
            // 
            // otherProtagonistToolStripMenuItem
            // 
            this.otherProtagonistToolStripMenuItem.Name = "otherProtagonistToolStripMenuItem";
            resources.ApplyResources(this.otherProtagonistToolStripMenuItem, "otherProtagonistToolStripMenuItem");
            this.otherProtagonistToolStripMenuItem.Click += new System.EventHandler(this.otherProtagonistToolStripMenuItem_Click);
            // 
            // unknownAuthorToolStripMenuItem
            // 
            this.unknownAuthorToolStripMenuItem.Name = "unknownAuthorToolStripMenuItem";
            resources.ApplyResources(this.unknownAuthorToolStripMenuItem, "unknownAuthorToolStripMenuItem");
            this.unknownAuthorToolStripMenuItem.Click += new System.EventHandler(this.unknownAuthorToolStripMenuItem_Click);
            // 
            // btnResetFilters
            // 
            resources.ApplyResources(this.btnResetFilters, "btnResetFilters");
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.UseVisualStyleBackColor = true;
            this.btnResetFilters.Click += new System.EventHandler(this.btnResetFilter_Click);
            // 
            // lblTagFilter
            // 
            this.lblTagFilter.AutoEllipsis = true;
            resources.ApplyResources(this.lblTagFilter, "lblTagFilter");
            this.lblTagFilter.Name = "lblTagFilter";
            // 
            // btnSetTagFilter
            // 
            resources.ApplyResources(this.btnSetTagFilter, "btnSetTagFilter");
            this.btnSetTagFilter.Name = "btnSetTagFilter";
            this.btnSetTagFilter.UseVisualStyleBackColor = true;
            this.btnSetTagFilter.Click += new System.EventHandler(this.btnSetTagFilter_Click);
            // 
            // tbFilter
            // 
            resources.ApplyResources(this.tbFilter, "tbFilter");
            this.tbFilter.Name = "tbFilter";
            this.toolTip1.SetToolTip(this.tbFilter, resources.GetString("tbFilter.ToolTip"));
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            this.tbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilter_KeyPress);
            // 
            // chkUnfinished
            // 
            resources.ApplyResources(this.chkUnfinished, "chkUnfinished");
            this.chkUnfinished.Name = "chkUnfinished";
            this.chkUnfinished.UseVisualStyleBackColor = true;
            this.chkUnfinished.CheckedChanged += new System.EventHandler(this.chkUnfinished_CheckedChanged);
            // 
            // btnFullScreenReadme
            // 
            resources.ApplyResources(this.btnFullScreenReadme, "btnFullScreenReadme");
            this.btnFullScreenReadme.Name = "btnFullScreenReadme";
            this.btnFullScreenReadme.UseVisualStyleBackColor = true;
            this.btnFullScreenReadme.Click += new System.EventHandler(this.fullScreenReadme_Click);
            // 
            // btnShowInBrowser
            // 
            resources.ApplyResources(this.btnShowInBrowser, "btnShowInBrowser");
            this.btnShowInBrowser.Name = "btnShowInBrowser";
            this.btnShowInBrowser.UseVisualStyleBackColor = true;
            this.btnShowInBrowser.Click += new System.EventHandler(this.btnShowInBrowser_Click);
            // 
            // webBrowser1
            // 
            resources.ApplyResources(this.webBrowser1, "webBrowser1");
            this.webBrowser1.Name = "webBrowser1";
            // 
            // readmeBox
            // 
            resources.ApplyResources(this.readmeBox, "readmeBox");
            this.readmeBox.ContextMenuStrip = this.rightClickReadme;
            this.readmeBox.Name = "readmeBox";
            this.readmeBox.ReadOnly = true;
            this.readmeBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            this.readmeBox.MouseEnter += new System.EventHandler(this.readmeBox_MouseEnter);
            // 
            // rightClickReadme
            // 
            this.rightClickReadme.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.rightClickReadme.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item1});
            this.rightClickReadme.Name = "rightClick";
            resources.ApplyResources(this.rightClickReadme, "rightClickReadme");
            // 
            // item1
            // 
            this.item1.Name = "item1";
            resources.ApplyResources(this.item1, "item1");
            this.item1.Click += new System.EventHandler(this.item1_Click);
            // 
            // btnPlOriginal
            // 
            resources.ApplyResources(this.btnPlOriginal, "btnPlOriginal");
            this.btnPlOriginal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPlOriginal.Name = "btnPlOriginal";
            this.btnPlOriginal.UseVisualStyleBackColor = true;
            this.btnPlOriginal.Click += new System.EventHandler(this.btnPlOriginal_Click);
            // 
            // btnPlFM
            // 
            resources.ApplyResources(this.btnPlFM, "btnPlFM");
            this.btnPlFM.Name = "btnPlFM";
            this.btnPlFM.UseVisualStyleBackColor = true;
            this.btnPlFM.Click += new System.EventHandler(this.btnPlFM_Click);
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnWebSearch);
            this.panel1.Controls.Add(this.btnPlOriginal);
            this.panel1.Controls.Add(this.btnPlFM);
            this.panel1.Controls.Add(this.btnInstallOnly);
            this.panel1.Controls.Add(this.btnTools);
            this.panel1.Controls.Add(this.btnSetup);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.progBar);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnWebSearch
            // 
            resources.ApplyResources(this.btnWebSearch, "btnWebSearch");
            this.btnWebSearch.Name = "btnWebSearch";
            this.btnWebSearch.UseVisualStyleBackColor = true;
            this.btnWebSearch.Click += new System.EventHandler(this.btnWebSearch_Click);
            // 
            // btnInstallOnly
            // 
            resources.ApplyResources(this.btnInstallOnly, "btnInstallOnly");
            this.btnInstallOnly.Name = "btnInstallOnly";
            this.btnInstallOnly.UseVisualStyleBackColor = true;
            this.btnInstallOnly.Click += new System.EventHandler(this.btnInstallOnly_Click);
            // 
            // btnTools
            // 
            resources.ApplyResources(this.btnTools, "btnTools");
            this.btnTools.Name = "btnTools";
            this.btnTools.UseVisualStyleBackColor = true;
            this.btnTools.Click += new System.EventHandler(this.btnTools_Click);
            // 
            // btnSetup
            // 
            resources.ApplyResources(this.btnSetup, "btnSetup");
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // progBar
            // 
            resources.ApplyResources(this.progBar, "progBar");
            this.progBar.Name = "progBar";
            // 
            // dlgSelectFixFile
            // 
            this.dlgSelectFixFile.FileName = "Archive(s)...";
            resources.ApplyResources(this.dlgSelectFixFile, "dlgSelectFixFile");
            this.dlgSelectFixFile.Multiselect = true;
            // 
            // dlgSaveFMINI
            // 
            this.dlgSaveFMINI.FileName = "fm.ini";
            resources.ApplyResources(this.dlgSaveFMINI, "dlgSaveFMINI");
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuTags;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlProgress.ResumeLayout(false);
            this.pnlProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fmTable)).EndInit();
            this.rightClickFM.ResumeLayout(false);
            this.gbTags.ResumeLayout(false);
            this.gbTags.PerformLayout();
            this.menuTags.ResumeLayout(false);
            this.menuTags.PerformLayout();
            this.rightClickReadme.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox readmeBox;
        private System.Windows.Forms.ContextMenuStrip rightClickReadme;
        private System.Windows.Forms.ToolStripMenuItem item1;
        private System.Windows.Forms.DataGridView fmTable;
        private System.Windows.Forms.ContextMenuStrip rightClickFM;
        private System.Windows.Forms.ToolStripMenuItem editFMDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.CheckBox chkUnfinished;
        private System.Windows.Forms.Button btnFullScreenReadme;
        private System.Windows.Forms.Button btnResetFilters;
        private System.Windows.Forms.Button btnPlOriginal;
        private System.Windows.Forms.Button btnPlFM;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnInstallOnly;
        private System.Windows.Forms.ProgressBar progBar;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnShowInBrowser;
        private System.Windows.Forms.Button btnTools;
        private System.Windows.Forms.GroupBox gbTags;
        private System.Windows.Forms.MenuStrip menuTags;
        private System.Windows.Forms.ToolStripMenuItem tagPresetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horrorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mysteryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puzzleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem czechToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dutchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frenchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem germanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hungarianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem italianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem japaneseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem russianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spanishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem campaignToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem demoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherProtagonistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unknownAuthorToolStripMenuItem;
        private System.Windows.Forms.TreeView tagTree;
        private System.Windows.Forms.Button btnAddExistTag;
        private System.Windows.Forms.Button btnRemoveTags;
        private System.Windows.Forms.Button btnSetTagFilter;
        private System.Windows.Forms.Label lblTagFilter;
        private System.Windows.Forms.Button btnHideTags;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem scanAllFMsToolStripMenuItem;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.Label lblArchive;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblProgressTitle;
        private System.Windows.Forms.ToolStripMenuItem rescanThisFMToolStripMenuItem;
        private System.Windows.Forms.TextBox tbAddTag;
        private System.Windows.Forms.ListBox lbTags;
        private System.Windows.Forms.Button btnAddNewTag;
        private System.Windows.Forms.Label lblFMTags;
        private System.Windows.Forms.Button btnTagPresets;
        private System.Windows.Forms.OpenFileDialog dlgSelectFixFile;
        private System.Windows.Forms.Button btnWebSearch;
        private System.Windows.Forms.ToolStripMenuItem generateFMiniToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog dlgSaveFMINI;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArchiveOrDir;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArchiveSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleHeading;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rating_;
        private System.Windows.Forms.DataGridViewImageColumn Finished_;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseDate_;
        private System.Windows.Forms.DataGridViewTextBoxColumn LstPlayed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cmnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoMod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ins;
        private System.Windows.Forms.ComboBox cbMaxYear;
        private System.Windows.Forms.ComboBox cbMaxMonth;
        private System.Windows.Forms.ComboBox cbMinYear;
        private System.Windows.Forms.ComboBox cbMinMonth;
    }
}

