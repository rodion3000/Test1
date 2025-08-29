using UnityEngine;
using System.IO;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class AssetBundlerLoader : MonoBehaviour
{
    // Укажите путь к папке с AssetBundles относительно папки Assets
    public string folderRelativePath = "Assets/AssetBundles";

    void Start()
    {
        // Получаем абсолютный путь к папке
        string folderPath = Path.Combine(Application.dataPath, folderRelativePath.Substring("Assets".Length));

        if (Directory.Exists(folderPath))
        {
            long totalSizeBytes = 0;
            string[] files = Directory.GetFiles(folderPath);

            foreach (string filePath in files)
            {
                // Можно фильтровать по расширению, если нужно
                // Например, если AssetBundles имеют расширение ".unity3d" или другое
                // if (Path.GetExtension(filePath) != ".unity3d") continue;

                long fileSize = new FileInfo(filePath).Length;
                totalSizeBytes += fileSize;

                Debug.Log($"Файл: {Path.GetFileName(filePath)} - {fileSize} байт");
            }

            Debug.Log($"Общий размер всех AssetBundles: {totalSizeBytes} байт");
        }
        else
        {
            Debug.LogError($"Папка не найдена: {folderPath}");
        }
        StopWatch();
    }

    void StopWatch()
    {
        // Создаем Stopwatch
        Stopwatch stopwatch = new Stopwatch();

        // Запускаем таймер перед загрузкой
        stopwatch.Start();

        // Загружаем AssetBundle
        AssetBundle bundle = AssetBundle.LoadFromFile(folderRelativePath);

        // Останавливаем таймер после загрузки
        stopwatch.Stop();

        if (bundle != null)
        {
            Debug.Log($"AssetBundle загружен за {stopwatch.ElapsedMilliseconds} миллисекунд");
            // Не забудьте выгрузить AssetBundle после использования
            bundle.Unload(false);
        }
        else
        {
            Debug.LogError($"Не удалось загрузить AssetBundle по пути: {folderRelativePath}");
        }
    }
}
