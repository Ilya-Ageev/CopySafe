namespace CopySafe
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var Disk = DriveInfo.GetDrives();

            foreach (var DiskItem in Disk)
            {
                if (DiskItem.IsReady && DiskItem.DriveType == DriveType.Removable)
                {
                    lstAllFlash.Items.Add($"{DiskItem.Name}{DiskItem.VolumeLabel}");
                }
            }
        }

        private void btnSearchFlash_Click(object sender, EventArgs e)
        {
            lstAllFlash.Items.Clear();
            var Disk = DriveInfo.GetDrives();

            foreach (var DiskItem in Disk)
            {
                if (DiskItem.IsReady && DiskItem.DriveType == DriveType.Removable)
                {
                    lstAllFlash.Items.Add($"{DiskItem.Name}{DiskItem.VolumeLabel}");
                }
            }
        }

        private void dataCopybtn_Click(object sender, EventArgs e)
        {
            if (lstAllFlash.SelectedIndex == -1)
            {
                MessageBox.Show("Сначала выберите флешку", "Ошибка!");
                return;
            }

            string flashName = lstAllFlash.SelectedItem.ToString().Substring(0, 3);
            string selectedFoldersPath = String.Empty;

            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFoldersPath = dialog.SelectedPath;
                }
                else
                {
                    return;
                }
            }

            bool existAnything = Directory.GetFiles(selectedFoldersPath).Length == 0 && Directory.GetDirectories(selectedFoldersPath).Length == 0;
            if (!existAnything)
            {
                DeleteFiles(flashName, selectedFoldersPath);
            }
            CopyDirectory(flashName, selectedFoldersPath);

        }
        private void CopyDirectory(string flash, string folder_path)
        {
            Directory.CreateDirectory(folder_path);

            foreach (var filePath in Directory.GetFiles(flash))
            {
                string fileName = Path.GetFileName(filePath);
                string destFile = Path.Combine(folder_path, fileName);
                File.Copy(filePath, destFile, true);
            }

            foreach (var directoryPath in Directory.GetDirectories(flash))
            {
                string dirName = Path.GetFileName(directoryPath);
                if(dirName.Equals("System Volume Information", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                string destDir = Path.Combine(folder_path, dirName);
                CopyDirectory(directoryPath, destDir);
            }
        }

        private void DeleteFiles(string flash, string folder_path)
        {
            foreach (var folderFile in Directory.GetFiles(folder_path))
            {
                bool exist = false;
                foreach (var flashFile in Directory.GetFiles(flash))
                {
                    if(Path.GetFileName(folderFile) == Path.GetFileName(flashFile))
                    {
                        exist = true;
                        break;
                    }
                }
                if (!exist)
                {
                    File.Delete(folderFile);
                }
            }

            string sup = String.Empty;
            foreach (var folderSubfolder in Directory.GetDirectories(folder_path))
            {
                bool exist = false;
                foreach(var flashSubfolder in Directory.GetDirectories(flash))
                {
                    if(Path.GetFileName(folderSubfolder) == Path.GetFileName(flashSubfolder))
                    {
                        exist = true;
                        sup = flashSubfolder;
                        break;
                    }
                }
                if (!exist)
                {
                    Directory.Delete(folderSubfolder, true);
                }
                else
                {
                    DeleteFiles(sup, folderSubfolder);
                }
            }
        }
    }
}
