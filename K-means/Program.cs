using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using TextClustering.Lib;
using select_review_to_label.k_Means;

namespace KMean
{
    class Program
    {
        static void Main(string[] args)
        {
            K_Means kmeans = new K_Means(2);

            kmeans.addDoc("平價牛排 淡水好店 吃吃喝喝 情侶約會 中價位 生日聚會 平價 節日聚會 家庭聚會 朋友聚會 吃到飽 異國料理 美式料理");
            kmeans.addDoc("平價 板橋美食 食記 小吃 單點式 麻辣鴨血 重慶路 涼麵 麻辣 鴨血 情侶約會 吃吃喝喝 涼皮 小吃店");
            kmeans.addDoc("客家美食 朋友聚會 客家菜 家庭聚會 苗栗 平價 預約 中價位 鶴山飯館 春酒 老店 單點式 免服務費 可包場 有包廂");
            kmeans.addDoc("下午茶 平價 免服務費 朋友聚會 景觀咖啡 巷弄隱密 家庭聚會 情侶約會 中價位 可帶寵物 無菜單 複合式 咖啡簡餐");
            kmeans.addDoc("台中泰式餐廳 中價位 泰式料理 月亮蝦餅 要預訂 單點式 魔幻廚房 家庭聚會 吃吃喝喝 朋友聚會 免服務費 節日聚會 大份量 泰式台菜 生日聚會");
            kmeans.addDoc("朋友聚會 中價位 吃吃喝喝 家庭聚會 單點式 印度料理 烤餅 平價 精緻料理 咖哩 可刷卡 生日聚會 異國料理 海尼根Light精選店家");
            kmeans.addDoc("婚宴 平價 家庭聚會 吃吃喝喝 單點式 可包場 有包廂 老店 主題特色餐廳 景觀餐廳");
            kmeans.addDoc("吃到飽 下午茶 有服務費 中價位 朋友聚會 巷弄隱密 情侶約會 家庭聚會 節日聚會 生日聚會 Buffet 複合式 複合式料理 2008新開店");
            kmeans.addDoc("情侶約會 法國料理 高價位 精緻料理 可刷卡 無菜單 節日聚會 家庭聚會 老店 吃吃喝喝 馬卡龍 朋友聚會 中價位 異國料理 法式料理");
            kmeans.addDoc("家庭聚會 烏龍麵 吃吃喝喝 單點式 贊岐烏龍麵 情侶約會 平價 朋友聚會 精緻料理 台南美食 贊岐廚房 日本料理 日式定食 台南餐廳 中價位");

            kmeans.train();

            //kmeans.getResult();

            kmeans.showResult();
            Console.ReadKey();
        }


    }
}
