
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestBot
{
    internal static class BotLib
    {
        static string[] poke = { "暴雪王", "凯西", "阿勃梭鲁", "敏捷虫", "坚盾剑怪", "化石翼龙", "波士可多拉", "长尾怪手", "胡地", "霜奶仙", "保姆曼波", "七夕青鸟", "冰雪龙", "双尾怪手", "败露球菇", "电龙", "太古羽虫", "丰蜜龙", "啃果虫", "滴蛛霸", "阿柏怪", "风速狗", "阿尔宙斯", "始祖小鸟", "始祖大鸟", "鳃鱼海兽", "雷鸟海兽", "阿利多斯", "太古盔甲", "芳香精", "可可多拉", "刺梭鱼", "急冻鸟", "差不多娃娃", "冰雪巨龙", "冰岩怪", "牙牙", "亚克诺姆", "玛力露丽", "露力丽", "宝贝龙", "天秤偶", "诅咒娃娃", "龟足巨铠", "泥泥鳅", "戽斗尖梭", "野蛮鲈鱼", "护城龙", "月桂叶", "冻原熊", "狩猎凤蝶", "大针蜂", "大宇怪", "铁哑铃", "美丽花", "喇叭芽", "冰宝", "穿着熊", "大尾狸", "大牙狸", "龟脚脚", "劈斩司令", "砰头小丑", "水箭龟", "火焰鸡", "索侦虫", "幸福蛋", "斑斑马", "地幔岩", "逐电犬", "盆才怪", "爆炸头水牛", "甜竹竹", "长尾火狐", "勇士雄鹰", "斗笠菇", "花漾海狮", "青铜钟", "铜镜怪", "磨牙彩皮鱼", "含羞苞", "泳圈鼬", "妙蛙种子", "卷卷耳", "掘掘兔", "结草儿", "巴大蝶", "爆肌蚊", "刺球仙人掌", "梦歌仙人掌", "喷火驼", "小碎钻", "大炭车", "尖牙笼", "肋骨海龟", "利牙鱼", "盾甲茧", "飘浮泡泡", "绿毛虫", "时拉比", "铁火辉夜", "焚焰蚣", "水晶灯火灵", "吉利蛋", "喷火龙", "虫电宝", "小火龙", "火恐龙", "聒噪鸟", "樱花儿", "樱花宝", "布里卡隆", "哈力栗", "咬咬龟", "菊草叶", "小火焰猴", "风铃铃", "灯笼鱼", "铃铛响", "奇诺栗鼠", "闪焰王牌", "珍珠贝", "铁臂枪虾", "钢炮臂虾", "念力土偶", "皮可西", "皮皮", "皮宝宝", "拳拳蛸", "刺甲贝", "巨炭山", "勾帕路翁", "迭失棺", "三蜜蜂", "力壮鸡", "花疗环环", "修建老匠", "大王铜象", "龙虾小兵", "太阳珊瑚", "钢铠鸦", "蓝鸦", "科斯莫姆", "科斯莫古", "木棉球", "好胜毛蟹", "好胜蟹", "摇篮百合", "古月鸟", "头盖龙", "铁螯龙虾", "克雷色利亚", "不良蛙", "叉字蝠", "蓝鳄", "岩殿居蟹", "几何雪花", "喷嚏熊", "卡拉卡拉", "铜象", "萌虻", "火球鼠", "达克莱伊", "达摩狒狒", "投羽枭", "火红不倒翁", "狙射树枭", "咚咚鼠", "四季鹿", "单首龙", "优雅猫", "信使鸟", "妖火红狐", "代欧奇希斯", "白海狮", "双刃丸", "滴蛛", "破破舵轮", "帝牙卢卡", "蒂安希", "掘地兔", "地鼠", "百变怪", "嘟嘟利", "嘟嘟", "顿甲", "天罩虫", "双剑鞘", "鳃鱼龙", "雷鸟龙", "毒藻龙", "多龙巴鲁托", "哈克龙", "快龙", "多龙奇", "老翁龙", "龙王蝎", "迷你龙", "暴噬龟", "多龙梅西亚", "随风球", "飘飘球", "螺钉地鼠", "变涩蜥", "催眠貘", "赤面龙", "毛毛角羊", "鸭宝宝", "三地鼠", "土龙弟弟", "双卵细胞球", "铝钢龙", "铁蚁", "彷徨夜灵", "黑夜魔灵", "夜巡灵", "毒粉蛾", "石居蟹", "麻麻鳗", "麻麻鳗鱼王", "伊布", "冰砌鹅", "阿柏蛇", "白蓬蓬", "电击兽", "电击魔兽", "落雷兽", "顽皮雷弹", "电击怪", "小灰怪", "炎武王", "电飞鼠", "帝王拿波", "炎帝", "骑士蜗牛", "太阳伊布", "妙喵", "龙头地鼠", "蛋蛋", "椰蛋树", "爆音怪", "列阵兵", "大葱鸭", "大嘴雀", "丑丑鱼", "火狐狸", "大力鳄", "种子铁球", "坚果哑铃", "荧光鱼", "茸茸羊", "花蓓蓓", "苹裹龙", "火伊布", "火箭雀", "小箭雀", "浮潜鼬", "花叶蒂", "花洁夫人", "沙漠蜻蜓", "伪螳草", "哎呀球菇", "佛烈托斯", "斧牙龙", "轻飘飘", "呱呱泡蛙", "呱头蛙", "雪妖女", "雪绒蛾", "多丽米亚", "大尾立", "尖牙陆鲨", "艾路雷朵", "电蜘蛛", "灰尘山", "烈咬陆鲨", "沙奈朵", "鬼斯", "海兔兽", "盖诺赛克特", "耿鬼", "小拳石", "圆陆鲨", "庞岩怪", "麒麟奇", "骑拉帝纳", "冰伊布", "冰鬼护", "魅力喵", "天蝎", "天蝎王", "臭臭花", "坐骑山羊", "大嘴蝠", "角金鱼", "哥达鸭", "隆隆岩", "泥偶小人", "具甲武者", "泥偶巨人", "黏美龙", "黏黏宝", "樱花鱼", "幼棉棉", "哥德宝宝", "哥德小姐", "哥德小童", "南瓜怪人", "布鲁皇", "八爪武师", "隆隆石", "藏饱栗鼠", "甲贺忍蛙", "臭泥", "长毛巨魔", "敲音猴", "树林龟", "固拉多", "森林蜥蜴", "卡蒂狗", "强颚鸡母虫", "噗噗猪", "溶食兽", "猫鼬探长", "铁骨土人", "恶食大王", "暴鲤龙", "鳞甲龙", "小福蛋", "铁掌力士", "迷布莉姆", "布莉姆温", "提布莉姆", "鬼斯通", "摔角鹰人", "双斧战龙", "熔蚁兽", "席多蓝恩", "光电伞蜥", "伞电蜥", "赫拉克罗斯", "哈约克", "沙河马", "河马兽", "快拳郎", "飞腿郎", "战舞郎", "凤王", "乌鸦头头", "独剑鞘", "胡帕", "咕咕", "毽子草", "墨海马", "黑鲁加", "戴鲁比", "猎斑鱼", "三首恶龙", "引梦貘人", "宝宝丁", "甜甜萤", "捣蛋小妖", "炽焰咆哮虎", "爱管侍", "烈焰猴", "好啦鱿", "千面避役", "妙蛙草", "心鳞宝", "胖嘟嘟", "胖丁", "基拉祈", "雷伊布", "电电虫", "毽子棉", "迷唇姐", "化石盔", "镰刀盔", "铁壳蛹", "袋兽", "盖盖虫", "纸御剑", "变隐龙", "凯路迪欧", "刺龙王", "巨钳蟹", "奇鲁莉安", "齿轮组", "钥圈儿", "齿轮儿", "齿轮怪", "瓦斯弹", "树枕尾熊", "杖尾鳞甲龙", "大钳蟹", "圆法师", "音箱蟀", "混混鳄", "流氓鳄", "熊徒弟", "盖欧卡", "酋雷姆", "可多拉", "灯火幽灵", "土地云", "电灯怪", "拉普拉斯", "燃烧虫", "幼基拉斯", "拉帝亚斯", "拉帝欧斯", "叶伊布", "保姆虫", "安瓢虫", "芭瓢虫", "大舌舔", "大舌头", "酷豹", "触手百合", "裙儿小姐", "小约克", "直冲熊", "小狮狮", "火斑喵", "烛光灵", "莲帽小童", "长耳兔", "莲叶童子", "吼爆弹", "路卡利欧", "乐天河童", "洛奇亚", "霓虹鱼", "露奈雅拉", "月石", "兰螳花", "爱心鱼", "勒克猫", "伦琴猫", "鬃岩狼人", "怪力", "豪力", "腕力", "鸭嘴宝宝", "熔岩蜗牛", "玛机雅娜", "鲤鱼王", "鸭嘴火兽", "鸭嘴炎兽", "小磁怪", "三合一磁怪", "自爆磁怪", "幕下力士", "乌贼王", "象牙猪", "玛纳霏", "秃鹰娜", "雷电兽", "猴怪", "巨翅飞鱼", "小球飞鱼", "沙铃仙人掌", "好坏星", "咩利羊", "玛力露", "嘎啦嘎啦", "玛夏多", "沼跃鱼", "雨翅蛾", "大嘴娃", "恰雷姆", "玛沙那", "大竺葵", "美录梅塔", "美洛耶塔", "美录坦", "超能妙喵", "喵喵", "艾姆利多", "巨金怪", "金属怪", "铁甲蛹", "梦幻", "超梦", "功夫鼬", "师父鼬", "大狼犬", "小仙奶", "美纳斯", "大奶罐", "魔尼尼", "谜拟丘", "泡沫栗鼠", "小陨星", "负电拍拍", "梦妖", "梦妖魔", "火焰鸟", "猛火猴", "睡睡菇", "诈唬魔", "莫鲁贝可", "绅士蛾", "魔墙人偶", "泥驴仔", "水跃鱼", "重泥挽马", "臭臭泥", "小卡比兽", "食梦梦", "黑暗鸦", "梦梦蚀", "四颚针龙", "天然雀", "奈克洛兹玛", "狡小狐", "尼多王", "尼多后", "尼多兰", "尼多朗", "尼多娜", "尼多力诺", "虚吾伊德", "土居忍士", "九尾", "铁面忍者", "猫头夜鹰", "嗡蝠", "音波龙", "朝北鼻", "呆火驼", "长鼻叶", "章鱼桶", "走路草", "菊石兽", "多刺菊石兽", "大岩蛇", "智挥猩", "以欧路普", "花舞鸟", "水水獭", "帕奇利兹", "帕路奇亚", "噬沙堡爷", "蓝蟾蜍", "顽皮熊猫", "霸道熊猫", "冷水猴", "花椰猴", "爆香猴", "派拉斯", "派拉斯特", "投掷猴", "探探鼠", "驹刀小兵", "大嘴鸥", "猫老大", "百合根娃娃", "小小象", "小木灵", "费洛美螂", "霏欧纳", "皮丘", "大比鸟", "比比鸟", "波波", "豆豆鸽", "炒炒猪", "皮卡丘", "小笃儿", "长毛猪", "啪嚓海胆", "榛果球", "凯罗斯", "波加曼", "正电拍拍", "毒贝比", "蚊香蛙皇", "蚊香蝌蚪", "蚊香君", "蚊香泳士", "怖思壶", "小火马", "土狼犬", "球球海狮", "多边兽", "多边兽乙型", "多边兽２型", "西狮海壬", "火暴猴", "波皇子", "大朝北鼻", "可达鸭", "南瓜精", "沙基拉斯", "扒手猫", "东施喵", "火炎狮", "拳海参", "沼王", "火岩鼠", "胖胖哈力", "千针鱼", "腾蹴小将", "雷丘", "雷公", "拉鲁拉丝", "战槌龙", "烈焰马", "拉达", "小拉达", "烈空坐", "雷吉艾斯", "雷吉铎拉戈", "雷吉艾勒奇", "雷吉奇卡斯", "雷吉洛克", "雷吉斯奇鲁", "古空棘鱼", "铁炮鱼", "莱希拉姆", "人造细胞卵", "钻角犀兽", "独角犀牛", "超甲狂犀", "蝶结萌虻", "轰擂金刚猩", "利欧路", "岩狗狗", "石丸子", "小炭仔", "稚山雀", "毒蔷薇", "罗丝雷朵", "洛托姆", "木木枭", "毛头小鹰", "勾魂眼", "暴飞龙", "夜盗火蜥", "焰后蜥", "大剑鬼", "沙螺蟒", "黑眼鳄", "穿山鼠", "穿山王", "沙丘娃", "打击鬼", "萌芽鹿", "粉蝶虫", "蜥蜴王", "巨钳螳螂", "蜈蚣王", "炎兔儿", "头巾混混", "滑滑小子", "飞天螳螂", "海刺龙", "金鱼王", "海魔狮", "橡实果", "小海狮", "蟾蜍王", "尾立", "君主蛇", "青藤蛇", "饭匙蛇", "虫宝包", "巨牙鲨", "谢米", "脱壳忍者", "甲壳龙", "大舌贝", "无壳海兔", "小嘴蜗", "盾甲龙", "狡猾天狗", "灯罩夜菇", "小猫怪", "蘑蘑菇", "壶壶", "怨影娃娃", "象征鸟", "甲壳茧", "沙包蛇", "银伴战兽", "冷水猿", "花椰猿", "爆香猿", "来悲茶", "烧火蚣", "盔甲鸟", "坐骑小羊", "毽子花", "向尾喵", "钳尾蝎", "垃垃藻", "坦克臭鼬", "贪心栗鼠", "请假王", "懒人獭", "黏美儿", "呆壳兽", "呆呆王", "呆呆兽", "熔岩虫", "胖甜妮", "图图犬", "迷唇娃", "狃拉", "藤藤蛇", "雪吞虫", "卡比兽", "雪童子", "雪笠怪", "布鲁", "泪眼蜥", "索尔迦雷欧", "单卵细胞球", "太阳岩", "烈雀", "粉蝶蛹", "海豹球", "圆丝蛛", "晃晃斑", "花岩怪", "跳跳猪", "粉香香", "杰尼龟", "垒磊石", "惊角鹿", "姆克鹰", "姆克鸟", "姆克儿", "宝石海星", "海星星", "大钢蛇", "甜舞妮", "巨石丁", "长毛狗", "童偶熊", "泥巴鱼", "臭鼬噗", "树才怪", "水君", "向日花怪", "向日种子", "溜溜糖球", "青绵鸟", "宝包茧", "吞食兽", "巨沼怪", "舞天鹅", "大王燕", "小山猪", "绵绵泡芙", "心蝙蝠", "仙子伊布", "傲骨燕", "烈箭鹰", "蔓藤怪", "巨蔓藤", "卡璞?哞哞", "卡璞?鳍鳍", "卡璞?鸣鸣", "卡璞?蝶蝶", "肯泰罗", "熊宝宝", "玛瑙水母", "毒刺水母", "暖暖猪", "代拉基翁", "猾大狐", "投摔鬼", "雷电云", "啪咚猴", "搬运小匠", "原盖海龟", "托戈德玛尔", "波克基斯", "波克比", "波克基古", "火稚鸡", "煤炭龟", "龙卷云", "炎热喵", "土台龟", "小锯鳄", "铳嘴大鸟", "超坏星", "电音婴", "毒骷蛙", "颤弦蝾螈", "咕咕鸽", "大颚蚁", "木守宫", "朽木妖", "热带龙", "破破袋", "喇叭啄鸟", "甜冷美后", "爆焰龟兽", "草苗龟", "圆蝌蚪", "麻麻小鱼", "属性：空", "火暴兽", "班基拉斯", "怪颚龙", "无畏小子", "宝宝暴龙", "月亮伊布", "高傲雉鸡", "未知图腾", "圈圈熊", "武道熊师", "由克希", "多多冰", "迷你冰", "双倍多多冰", "水伊布", "百足蜈蚣", "摩鲁蛾", "毛球", "妙蛙花", "蜂女王", "超音波幼虫", "比克提尼", "大食花", "过动猿", "锹农炮虫", "霸王花", "毕力吉翁", "彩粉蝶", "电萤虫", "波尔凯尼恩", "火神蛾", "霹雳电球", "秃鹰丫头", "六尾", "吼吼鲸", "吼鲸王", "帝牙海狮", "卡咪龟", "步哨鼠", "玛狃拉", "独角虫", "口呆花", "双弹瓦斯", "风妖精", "车轮球", "鲶鱼王", "咕妞妞", "胖可丁", "胆小虫", "长翅鸥", "弱丁鱼", "果然翁", "滚滚蝙蝠", "毛辫羊", "乌波", "结草贵妇", "刺尾虫", "小果然", "天然鸟", "哲尔尼亚斯", "电束木", "哭哭面具", "来电汪", "蜻蜻蜓", "远古巨蜓", "猫鼬少", "伊裴尔塔尔", "苍响", "藏玛然特", "猫鼬斩", "闪电鸟", "萨戮德", "雷电斑马", "捷克罗姆", "捷拉奥拉", "蛇纹熊", "索罗亚克", "索罗亚", "超音蝠", "双首暴龙", "基格尔德", "增田顺一", "大森滋", "魔墙人偶" };
        static HttpClient _httpClient = new HttpClient();
        static int idx = 0;
        static int idxx = 1000;
        public static async Task<bool> DownloadImage(string path, string url)
        {
            var img = await (await _httpClient.GetAsync(url)).Content.ReadAsByteArrayAsync();

            if (img.Length == 0)
            {
                return false;
            }
            else
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                File.WriteAllBytes($"{path}/{Directory.GetFiles(path).Length}.jpg", img);
                return true;
            }
        }
        static string[] pokeeng = { "Abomasnow", "Abra", "Absol", "Accelgor", "Aegislash", "Aerodactyl", "Aggron", "Aipom", "Alakazam", "Alcremie", "Alomomola", "Altaria", "Amaura", "Ambipom", "Amoonguss", "Ampharos", "Anorith", "Appletun", "Applin", "Araquanid", "Arbok", "Arcanine", "Arceus", "Archen", "Archeops", "Arctovish", "Arctozolt", "Ariados", "Armaldo", "Aromatisse", "Aron", "Arrokuda", "Articuno", "Audino", "Aurorus", "Avalugg", "Axew", "Azelf", "Azumarill", "Azurill", "Bagon", "Baltoy", "Banette", "Barbaracle", "Barboach", "Barraskewda", "Basculin", "Bastiodon", "Bayleef", "Beartic", "Beautifly", "Beedrill", "Beheeyem", "Beldum", "Bellossom", "Bellsprout", "Bergmite", "Bewear", "Bibarel", "Bidoof", "Binacle", "Bisharp", "Blacephalon", "Blastoise", "Blaziken", "Blipbug", "Blissey", "Blitzle", "Boldore", "Boltund", "Bonsly", "Bouffalant", "Bounsweet", "Braixen", "Braviary", "Breloom", "Brionne", "Bronzong", "Bronzor", "Bruxish", "Budew", "Buizel", "Bulbasaur", "Buneary", "Bunnelby", "Burmy", "Butterfree", "Buzzwole", "Cacnea", "Cacturne", "Camerupt", "Carbink", "Carkol", "Carnivine", "Carracosta", "Carvanha", "Cascoon", "Castform", "Caterpie", "Celebi", "Celesteela", "Centiskorch", "Chandelure", "Chansey", "Charizard", "Charjabug", "Charmander", "Charmeleon", "Chatot", "Cherrim", "Cherubi", "Chesnaught", "Chespin", "Chewtle", "Chikorita", "Chimchar", "Chimecho", "Chinchou", "Chingling", "Cinccino", "Cinderace", "Clamperl", "Clauncher", "Clawitzer", "Claydol", "Clefable", "Clefairy", "Cleffa", "Clobbopus", "Cloyster", "Coalossal", "Cobalion", "Cofagrigus", "Combee", "Combusken", "Comfey", "Conkeldurr", "Copperajah", "Corphish", "Corsola", "Corviknight", "Corvisquire", "Cosmoem", "Cosmog", "Cottonee", "Crabominable", "Crabrawler", "Cradily", "Cramorant", "Cranidos", "Crawdaunt", "Cresselia", "Croagunk", "Crobat", "Croconaw", "Crustle", "Cryogonal", "Cubchoo", "Cubone", "Cufant", "Cutiefly", "Cyndaquil", "Darkrai", "Darmanitan", "Dartrix", "Darumaka", "Decidueye", "Dedenne", "Deerling", "Deino", "Delcatty", "Delibird", "Delphox", "Deoxys", "Dewgong", "Dewott", "Dewpider", "Dhelmise", "Dialga", "Diancie", "Diggersby", "Diglett", "Ditto", "Dodrio", "Doduo", "Donphan", "Dottler", "Doublade", "Dracovish", "Dracozolt", "Dragalge", "Dragapult", "Dragonair", "Dragonite", "Drakloak", "Drampa", "Drapion", "Dratini", "Drednaw", "Dreepy", "Drifblim", "Drifloon", "Drilbur", "Drizzile", "Drowzee", "Druddigon", "Dubwool", "Ducklett", "Dugtrio", "Dunsparce", "Duosion", "Duraludon", "Durant", "Dusclops", "Dusknoir", "Duskull", "Dustox", "Dwebble", "Eelektrik", "Eelektross", "Eevee", "Eiscue", "Ekans", "Eldegoss", "Electabuzz", "Electivire", "Electrike", "Electrode", "Elekid", "Elgyem", "Emboar", "Emolga", "Empoleon", "Entei", "Escavalier", "Espeon", "Espurr", "Excadrill", "Exeggcute", "Exeggutor", "Exploud", "Falinks", "Farfetch’d", "Fearow", "Feebas", "Fennekin", "Feraligatr", "Ferroseed", "Ferrothorn", "Finneon", "Flaaffy", "Flabébé", "Flapple", "Flareon", "Fletchinder", "Fletchling", "Floatzel", "Floette", "Florges", "Flygon", "Fomantis", "Foongus", "Forretress", "Fraxure", "Frillish", "Froakie", "Frogadier", "Froslass", "Frosmoth", "Furfrou", "Furret", "Gabite", "Gallade", "Galvantula", "Garbodor", "Garchomp", "Gardevoir", "Gastly", "Gastrodon", "Genesect", "Gengar", "Geodude", "Gible", "Gigalith", "Girafarig", "Giratina", "Glaceon", "Glalie", "Glameow", "Gligar", "Gliscor", "Gloom", "Gogoat", "Golbat", "Goldeen", "Golduck", "Golem", "Golett", "Golisopod", "Golurk", "Goodra", "Goomy", "Gorebyss", "Gossifleur", "Gothita", "Gothitelle", "Gothorita", "Gourgeist", "Granbull", "Grapploct", "Graveler", "Greedent", "Greninja", "Grimer", "Grimmsnarl", "Grookey", "Grotle", "Groudon", "Grovyle", "Growlithe", "Grubbin", "Grumpig", "Gulpin", "Gumshoos", "Gurdurr", "Guzzlord", "Gyarados", "Hakamo-o", "Happiny", "Hariyama", "Hatenna", "Hatterene", "Hattrem", "Haunter", "Hawlucha", "Haxorus", "Heatmor", "Heatran", "Heliolisk", "Helioptile", "Heracross", "Herdier", "Hippopotas", "Hippowdon", "Hitmonchan", "Hitmonlee", "Hitmontop", "Ho-Oh", "Honchkrow", "Honedge", "Hoopa", "Hoothoot", "Hoppip", "Horsea", "Houndoom", "Houndour", "Huntail", "Hydreigon", "Hypno", "Igglybuff", "Illumise", "Impidimp", "Incineroar", "Indeedee", "Infernape", "Inkay", "Inteleon", "Ivysaur", "Jangmo-o", "Jellicent", "Jigglypuff", "Jirachi", "Jolteon", "Joltik", "Jumpluff", "Jynx", "Kabuto", "Kabutops", "Kakuna", "Kangaskhan", "Karrablast", "Kartana", "Kecleon", "Keldeo", "Kingdra", "Kingler", "Kirlia", "Klang", "Klefki", "Klink", "Klinklang", "Koffing", "Komala", "Kommo-o", "Krabby", "Kricketot", "Kricketune", "Krokorok", "Krookodile", "Kubfu", "Kyogre", "Kyurem", "Lairon", "Lampent", "Landorus", "Lanturn", "Lapras", "Larvesta", "Larvitar", "Latias", "Latios", "Leafeon", "Leavanny", "Ledian", "Ledyba", "Lickilicky", "Lickitung", "Liepard", "Lileep", "Lilligant", "Lillipup", "Linoone", "Litleo", "Litten", "Litwick", "Lombre", "Lopunny", "Lotad", "Loudred", "Lucario", "Ludicolo", "Lugia", "Lumineon", "Lunala", "Lunatone", "Lurantis", "Luvdisc", "Luxio", "Luxray", "Lycanroc", "Machamp", "Machoke", "Machop", "Magby", "Magcargo", "Magearna", "Magikarp", "Magmar", "Magmortar", "Magnemite", "Magneton", "Magnezone", "Makuhita", "Malamar", "Mamoswine", "Manaphy", "Mandibuzz", "Manectric", "Mankey", "Mantine", "Mantyke", "Maractus", "Mareanie", "Mareep", "Marill", "Marowak", "Marshadow", "Marshtomp", "Masquerain", "Mawile", "Medicham", "Meditite", "Meganium", "Melmetal", "Meloetta", "Meltan", "Meowstic", "Meowth", "Mesprit", "Metagross", "Metang", "Metapod", "Mew", "Mewtwo", "Mienfoo", "Mienshao", "Mightyena", "Milcery", "Milotic", "Miltank", "Mime Jr.", "Mimikyu", "Minccino", "Minior", "Minun", "Misdreavus", "Mismagius", "Moltres", "Monferno", "Morelull", "Morgrem", "Morpeko", "Mothim", "Mr. Mime", "Mudbray", "Mudkip", "Mudsdale", "Muk", "Munchlax", "Munna", "Murkrow", "Musharna", "Naganadel", "Natu", "Necrozma", "Nickit", "Nidoking", "Nidoqueen", "Nidoran♀", "Nidoran♂", "Nidorina", "Nidorino", "Nihilego", "Nincada", "Ninetales", "Ninjask", "Noctowl", "Noibat", "Noivern", "Nosepass", "Numel", "Nuzleaf", "Octillery", "Oddish", "Omanyte", "Omastar", "Onix", "Oranguru", "Orbeetle", "Oricorio", "Oshawott", "Pachirisu", "Palkia", "Palossand", "Palpitoad", "Pancham", "Pangoro", "Panpour", "Pansage", "Pansear", "Paras", "Parasect", "Passimian", "Patrat", "Pawniard", "Pelipper", "Persian", "Petilil", "Phanpy", "Phantump", "Pheromosa", "Phione", "Pichu", "Pidgeot", "Pidgeotto", "Pidgey", "Pidove", "Pignite", "Pikachu", "Pikipek", "Piloswine", "Pincurchin", "Pineco", "Pinsir", "Piplup", "Plusle", "Poipole", "Politoed", "Poliwag", "Poliwhirl", "Poliwrath", "Polteageist", "Ponyta", "Poochyena", "Popplio", "Porygon", "Porygon-Z", "Porygon2", "Primarina", "Primeape", "Prinplup", "Probopass", "Psyduck", "Pumpkaboo", "Pupitar", "Purrloin", "Purugly", "Pyroar", "Pyukumuku", "Quagsire", "Quilava", "Quilladin", "Qwilfish", "Raboot", "Raichu", "Raikou", "Ralts", "Rampardos", "Rapidash", "Raticate", "Rattata", "Rayquaza", "Regice", "Regidrago", "Regieleki", "Regigigas", "Regirock", "Registeel", "Relicanth", "Remoraid", "Reshiram", "Reuniclus", "Rhydon", "Rhyhorn", "Rhyperior", "Ribombee", "Rillaboom", "Riolu", "Rockruff", "Roggenrola", "Rolycoly", "Rookidee", "Roselia", "Roserade", "Rotom", "Rowlet", "Rufflet", "Sableye", "Salamence", "Salandit", "Salazzle", "Samurott", "Sandaconda", "Sandile", "Sandshrew", "Sandslash", "Sandygast", "Sawk", "Sawsbuck", "Scatterbug", "Sceptile", "Scizor", "Scolipede", "Scorbunny", "Scrafty", "Scraggy", "Scyther", "Seadra", "Seaking", "Sealeo", "Seedot", "Seel", "Seismitoad", "Sentret", "Serperior", "Servine", "Seviper", "Sewaddle", "Sharpedo", "Shaymin", "Shedinja", "Shelgon", "Shellder", "Shellos", "Shelmet", "Shieldon", "Shiftry", "Shiinotic", "Shinx", "Shroomish", "Shuckle", "Shuppet", "Sigilyph", "Silcoon", "Silicobra", "Silvally", "Simipour", "Simisage", "Simisear", "Sinistea", "Sizzlipede", "Skarmory", "Skiddo", "Skiploom", "Skitty", "Skorupi", "Skrelp", "Skuntank", "Skwovet", "Slaking", "Slakoth", "Sliggoo", "Slowbro", "Slowking", "Slowpoke", "Slugma", "Slurpuff", "Smeargle", "Smoochum", "Sneasel", "Snivy", "Snom", "Snorlax", "Snorunt", "Snover", "Snubbull", "Sobble", "Solgaleo", "Solosis", "Solrock", "Spearow", "Spewpa", "Spheal", "Spinarak", "Spinda", "Spiritomb", "Spoink", "Spritzee", "Squirtle", "Stakataka", "Stantler", "Staraptor", "Staravia", "Starly", "Starmie", "Staryu", "Steelix", "Steenee", "Stonjourner", "Stoutland", "Stufful", "Stunfisk", "Stunky", "Sudowoodo", "Suicune", "Sunflora", "Sunkern", "Surskit", "Swablu", "Swadloon", "Swalot", "Swampert", "Swanna", "Swellow", "Swinub", "Swirlix", "Swoobat", "Sylveon", "Taillow", "Talonflame", "Tangela", "Tangrowth", "Tapu Bulu", "Tapu Fini", "Tapu Koko", "Tapu Lele", "Tauros", "Teddiursa", "Tentacool", "Tentacruel", "Tepig", "Terrakion", "Thievul", "Throh", "Thundurus", "Thwackey", "Timburr", "Tirtouga", "Togedemaru", "Togekiss", "Togepi", "Togetic", "Torchic", "Torkoal", "Tornadus", "Torracat", "Torterra", "Totodile", "Toucannon", "Toxapex", "Toxel", "Toxicroak", "Toxtricity", "Tranquill", "Trapinch", "Treecko", "Trevenant", "Tropius", "Trubbish", "Trumbeak", "Tsareena", "Turtonator", "Turtwig", "Tympole", "Tynamo", "Type: Null", "Typhlosion", "Tyranitar", "Tyrantrum", "Tyrogue", "Tyrunt", "Umbreon", "Unfezant", "Unown", "Ursaring", "Urshifu", "Uxie", "Vanillish", "Vanillite", "Vanilluxe", "Vaporeon", "Venipede", "Venomoth", "Venonat", "Venusaur", "Vespiquen", "Vibrava", "Victini", "Victreebel", "Vigoroth", "Vikavolt", "Vileplume", "Virizion", "Vivillon", "Volbeat", "Volcanion", "Volcarona", "Voltorb", "Vullaby", "Vulpix", "Wailmer", "Wailord", "Walrein", "Wartortle", "Watchog", "Weavile", "Weedle", "Weepinbell", "Weezing", "Whimsicott", "Whirlipede", "Whiscash", "Whismur", "Wigglytuff", "Wimpod", "Wingull", "Wishiwashi", "Wobbuffet", "Woobat", "Wooloo", "Wooper", "Wormadam", "Wurmple", "Wynaut", "Xatu", "Xerneas", "Xurkitree", "Yamask", "Yamper", "Yanma", "Yanmega", "Yungoos", "Yveltal", "Zacian", "Zamazenta", "Zangoose", "Zapdos", "Zarude", "Zebstrika", "Zekrom", "Zeraora", "Zigzagoon", "Zoroark", "Zorua", "Zubat", "Zweilous", "Zygarde", "masuda", "ohmori", "mrmime" };

        public static Dictionary<string, string> pokeTable = PokeTableInit();

        private static Dictionary<string, string> PokeTableInit()
        {
            Dictionary<string, string> pokeTablet = new();
            for (int i = 0; i < poke.Length; ++i)
            {
                pokeTablet.Add(pokeeng[i].ToLower(), poke[i]);
            }
            //   pokeTablet.Add(pokeeng[899].ToLower(), poke[899]);
            //   pokeTablet.Add(pokeeng[900].ToLower(), poke[900]);
            return pokeTablet;
        }



        #region 龙葵
        public static string[] 阮郎归 = new[]
        {
            "临流揽镜曳双魂, 落红逐青裙",
            "依稀往梦幻如真, 泪湿千里云",
            "风骤暖, 草渐新, 年年秋复春",
            "温香软玉燕依人, 再启生死门",
        };

        public static string[] 失魂雨 = new[]
        {
            "纷纷雪落人飘坠, 同死生, 共玉碎",
            "前尘后世君莫问, 柔肠百结如醉",
            "情丝未断, 尘缘难了, 萦绕千千岁",
            "舍却残生犹不悔, 身已空, 尽成泪",
            "路长梦短无寻处, 总是情愁滋味",
            "眉间心上, 柔肠百结, 尽付东流水",
        };

        public static string[] 寥落风 = new[]
        {
            "大梦初醒已千年, 凌乱罗衫, 料峭风寒",
            "放眼难觅旧衣冠, 疑真疑幻, 如梦如烟",
            "看朱成碧心迷乱, 莫问生前, 但惜因缘",
            "魂无归处为情牵, 贪恋人间, 不羡神仙",
        };

        public static string[] 蓝葵结局 = new[]
        {
            "你...为什么要走...?",
            "因为爱...是不可以被分享的...",
            "不是说, 你就是我, 我就是你吗?",
            "我是你最无助的时候创造出来的",
            "保护你的影子...",
            "现在...你找到可以保护自己的人了, 我该离开了...",
            "你...去哪里?",
            "去找一个...可以保护我的人",
            "一定会有这样一个人, 在某个地方，某个时代，等待着...",
            "我...很担心",
            "不用担心~ 照我说的去做, 一定会得到幸福的",
            "我担心你...",
            "不用担心，我也...会得到幸福的。",
            "他快来了, 准备好! 记得微笑, 如果喜欢, 就大声说出来",
        };

        public static string[] 小光角色歌 = new[]
        {
            "ピンクに輝く",
            "粉红闪亮的",
            "自慢のポケッチ",
            "自豪的神奇宝贝表",
            "迷った時には",
            "迷茫的时候",
            "コイントスをして",
            "就抛硬币决定吧",
            "いつでもまっすぐ",
            "总是注视着",
            "前をみつめてる",
            "正前方",
            "強くなれる",
            "在你身旁",
            "君のそばで力になれる",
            "助你一臂之力",
            "「ガンバレ」っていうより",
            "与其喊「加油吧」",
            "「ダイジョウブ」って伝えたい",
            "我还比较想传达「没问题的」",
            "信じる勇気あれば",
            "只要有相信的勇气",
            "Go go go",
            "Go go go",
            "君となら",
            "是与你一起的话",
            "Yeah一緒に",
            "Yeah一起",
            "Step",
            "跨步",
            "大きく",
            "大力地",
            "Jump",
            "跳跃",
            "飛び越えてゆけるだろう",
            "应该就可以越过了吧",
            "どんな山も",
            "不论面对",
            "どんな谷もこわくないさ",
            "什么样的山与谷",
            "みんなで",
            "大家一起",
            "Yeah一緒に",
            "Yeah一起",
            "Step",
            "跨步",
            "明日へ",
            "往明天",
            "Jump",
            "跳跃",
            "いますぐ瞬間を感じて",
            "现在马上感觉这一瞬间",
            "走り出そう風に乗って",
            "起步奔跑吧乘着风",
            "もっと強く",
            "变得更强"
        };
        public static string[] 浙大校歌 = new[]
        {
           "大不自多, 海纳江河", 
            "惟学无际, 际于天地", 
            "形上谓道兮, 形下谓器", 
            "礼主别异兮, 乐主和同", 
            "知其不二兮, 尔听斯聪", 
            "国有成均, 在浙之滨", 
            "昔言求是, 实启尔求真", 
            "习坎示教, 始见经纶", 
            "无曰已是, 无曰遂真", 
            "靡革匪因, 靡故匪新", 
            "何以新之, 开物前民", 
            "嗟尔髦士, 尚其有闻", 
            "念哉典学, 思睿观通", 
            "有文有质, 有农有工", 
            "兼总条贯, 知至知终", 
            "成章乃达, 若金之在熔", 
            "尚亨于野, 无吝于宗", 
            "树我邦国, 天下来同", 
        };
        public static string[] 黯淡蓝点 =
        {
            "旅行者号拍摄的最后一张照片来自于他的想法",
            "在一代人以前",
            "阿波罗登月飞行的最后一位宇航员, 照下了一张地球的全景照片。",
            "这是一个没有边界的行星, 它成了一种新意识的象征, 卡尔实现了这个过程的下一步, 他说服了美国宇航局把旅行者一号的镜头, 在飞过海王星时, 转回地球。让它最后看一眼家园, 他所说的那个, 泛着苍白蓝光的小点。",
            "在那里, 那是家园。",
            "那是我们。",
            "在那里, 你爱的每个人",
            "你认识的每个人",
            "你听说过的每个人",
            "在这世上存在过的每个人",
            "度过了自己的一生",
            "聚集在这里的, 是我们的欢乐和痛苦",
            "是成千上万的宗教信仰、意识形态",
            "和经济学说",
            "每个猎手与觅食者",
            "每个英雄与懦夫",
            "每个文明的创立者和毁灭者",
            "每个国王与农夫",
            "每对年轻的爱侣",
            "每一个母亲与父亲、充满希望的孩子们",
            "发明家与探险家",
            "每一位高尚的教师、每一位贪腐的政客",
            "每一位超级明星、每一位最高领袖",
            "人类史上的每一位圣人和罪人, 都生活在这里",
            "如一粒微尘, 悬浮在一束阳光之中",
            "地球是一个很小的舞台",
            "在浩瀚的宇宙背景下",
            "想想过去的血流成河",
            "那为帝王将相而流的血",
            "只为让他们在光荣和胜利中, 成为瞬间的伟人",
            "占有那一个小点中…那一小部分",
            "想想那无尽的残酷",
            "图像里那一个像素点的某个角落的民众",
            "每天把这残酷施加到与他们没什么区别的",
            "另一个角落的民众身上",
            "他们为何常常误解",
            "他们为何渴望杀死对方",
            "他们的憎恨为何如此狂热",
            "我们在装模做样",
            "我们自以为很重要",
            "妄想着我们人类地位特殊",
            "在宇宙中与众不同",
            "这一切, 都因这泛着苍白蓝光的小点而动摇",
            "我们的星球, 不过是一粒孤独的微尘",
            "笼罩在伟大的宇宙黑暗之中, , 我们默默无闻",
            "沉浸在无尽的浩瀚里",
            "没有一丝线索显示",
            "除了我们自己",
            "还有谁能拯救我们",
            "地球是目前已知唯一有生命的世界, 生命再无其他去处",
            "至少在不久的将来, 亦是如此, 没有外星球, 供人类迁移",
            "参观, 可以",
            "定居, 不行",
            "不管你喜欢与否",
            "现在, 只有地球供我们立足",
            "据说研习天文",
            "可以让人谦卑",
            "塑造人心, 磨炼个性",
            "也许再没有更好的方法",
            "能比这遥远的画面",
            "更好地显示出人类的自负与愚蠢",
            "对我而言, 它强调了我们的责任",
            "要对人更友善",
            "懂得珍惜与爱护",
            "这泛着苍白蓝光的小点"
        };
        public static string[] 幽弥狂的狂怒 = new string[]
        {
            "不是几个私友！是五个战士！五个有名有姓的战士！",
            "白落提，丰和，英宋，桓泽金，广秀！",
            "(镜头转到回忆中的夜晚，幽弥狂开始行动...)",
            "(迷麟阻止了大仓的动作，等待幽弥狂的到来...)",
            "(幽弥狂闯入后，被一手按住)",
            "白落提，丰和，英宋，桓泽金，广秀...",
            "于魁拔1026年，加入神圣联军南部战区夜战小队",
            "与魁拔英勇作战，历经战事一百七十一次，杀敌五百二十六名！",
            "于五天前，在魁拔的营地里阵亡！",
            "我是他们的长官雾妖族妖侠幽弥狂！现在，我要为他们复仇！",
            // "(大仓留下了泪水)",
            "勇气可嘉，可是.. 你根本没可能取胜的",
            "知道你很强大，我们很难战胜",
            "可是，我就是要用行动来表达一个态度！我是你的敌人！",
            "即使.. 我们现在连做魁拔的敌人的资格都没有！",
            "(迷麟一手推开他，说到)",
            "大家听好了，白落提，丰和，英宋，桓泽金，广秀",
            "这五个人，将因为誓死捍卫故乡抵抗魁拔，而被所有灵山军官兵记住，并视为死敌",
            "现在，我要为在夜袭中死去的那五百二十六名将士们复仇，现在...",
            "\"魁拔没有命令部队进攻，而是趁着浓浓的夜色，只身与我闯入联军营地...\"",
            "(一阵厮杀后，幽弥狂的长官阵亡...)",
            "现在，我已经为我的兄弟们复了仇",
            "你什么时候才能强大到，为你的兄弟，向我复仇啊？",
            "总有一天... 总有一天！",
            "(画面回到魁拔营地)",
            "饭好了",
            "(魁拔开始吃饭)",
            "魁拔，你给我记住，我是你的敌人！",
            "死敌",
            "(幽弥狂开始吃饭)",
            "死敌！",
        };

        public static string[] AStepAway = new string[]
        {
            "Here I am, staring at my own palms",
            "I feel the warmth of your hand",
            "I thought I’d be forever by your side, protecting you",
            "Assuming that’s what you wanted to",
            "I had no clue, that we had nothing between us",
            "Perhaps I was so scared to know the truth",
            "Now that you’re gone, and yet your love is still embracing me",
            "I’m at a loss, I need you with me",
            "It’s like I’m drowning, as if I’ve lost the way",
            "But you always appear as if you guide my way",
            "I thought I could do it all, I had my confidence",
            "But now I’m left alone with no one by my end",
            "I knew my faults, but I pretended I didn’t know",
            "I fear I’m not the kind of man you know",
            "I see you smile, pretending everything is alright",
            "But that made me feel more in misery",
            "I don’t know where to start, there is nothing left for me",
            "I know I’ve lost it all except the memories",
            "When I have my chin up high, I see a glimpse of light",
            "Like how we find the brightest star up in the sky",
            "I now have the courage to show you there is a way",
            "You told me silently I know what you will say",
            "And when I search for you, I see a guiding light",
            "It’s now so clear to me that you’re still far away",
            "A step away",

        };


        #endregion

        static string URL_DETAIL = "https://manga.bilibili.com/twirp/comic.v2.Comic/ComicDetail?device=pc&platform=web";
        static string URL_IMAGE_INDEX = "https://manga.bilibili.com/twirp/comic.v1.Comic/GetImageIndex?device=pc&platform=web";
        static string URL_MANGA_HOST = "https://manga.hdslb.com";
        static string URL_IMAGE_TOKEN = "https://manga.bilibili.com/twirp/comic.v1.Comic/ImageToken?device=pc&platform=web";

        public static async Task<JsonElement> GetChapters(int ComicId)
        {
            HttpClient MangaHttpClient = new HttpClient();
            MangaHttpClient.DefaultRequestHeaders.Add("Cookie", "SESSDATA=045e584c%2C1649390286%2Cecc98%2Aa1");
            var res = await MangaHttpClient.PostAsJsonAsync(
                URL_DETAIL, new { comic_id = ComicId });
            var data = await res.Content.ReadFromJsonAsync<JsonElement>();
            data = data.GetProperty("data");
            Console.WriteLine(data.GetProperty("title"));
            Console.WriteLine(data.GetProperty("evaluate"));
            return data;
            //return data.GetProperty("ep_list");
        }
        public static async Task<List<string>> GetImages(int EPId)
        {
            HttpClient MangaHttpClient = new HttpClient();
            MangaHttpClient.DefaultRequestHeaders.Add("Cookie", "SESSDATA=045e584c%2C1649390286%2Cecc98%2Aa1");
            var res1 =
                await MangaHttpClient.PostAsJsonAsync("https://manga.bilibili.com/twirp/comic.v1.Comic/GetImageIndex?device=pc&platform=web",
                new { ep_id = EPId });
            var mangaData = await res1.Content.ReadFromJsonAsync<JsonElement>();
            mangaData = mangaData.GetProperty("data").GetProperty("images");
            List<string> urls = new();
            for (int j = 0; j < mangaData.GetArrayLength(); j++)
            {
                urls.Add(mangaData[j].GetProperty("path").GetString());
            }
            return await GetFullUrls(urls);
        }
        static async Task<List<string>> GetFullUrls(List<string> urls)
        {
            HttpClient MangaHttpClient = new HttpClient();
            MangaHttpClient.DefaultRequestHeaders.Add("Cookie", "SESSDATA=045e584c%2C1649390286%2Cecc98%2Aa1");
            var res = await MangaHttpClient.PostAsJsonAsync(URL_IMAGE_TOKEN, new { urls = JsonSerializer.Serialize(urls) });
            var data = (await res.Content.ReadFromJsonAsync<JsonElement>()).GetProperty("data");
            List<string> picres = new();
            for (int i = 0; i < data.GetArrayLength(); i++)
            {
                picres.Add($"{data[i].GetProperty("url")}?token={data[i].GetProperty("token")}");
            }
            return picres;
        }
    }


}
