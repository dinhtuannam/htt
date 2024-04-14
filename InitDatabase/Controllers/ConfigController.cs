using InitDatabase.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InitDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly DataContext context;
        public ConfigController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("init-action")]
        public async Task<IActionResult> initAction()
        {
            SqlAction? action = context.actions!.Where(s => s.id.CompareTo("DATBAN") == 0 && s.isdeleted == false).FirstOrDefault();
            if (action == null)
            {
                SqlAction tmp = new SqlAction();
                tmp.id = "DATBAN";
                tmp.name = "Đặt bàn";
                tmp.des = "Đặt bàn";
                context.actions!.Add(tmp);
            }
            action = context.actions!.Where(s => s.id.CompareTo("DATMONAN") == 0 && s.isdeleted == false).FirstOrDefault();

            if (action == null)
            {
                SqlAction tmp = new SqlAction();
                tmp.id = "DATMONAN";
                tmp.name = "Đặt món";
                tmp.des = "Đặt món";
                context.actions!.Add(tmp);
            }
            action = context.actions!.Where(s => s.id.CompareTo("THANHTOAN") == 0 && s.isdeleted == false).FirstOrDefault();

            if (action == null)
            {
                SqlAction tmp = new SqlAction();
                tmp.id = "THANHTOAN";
                tmp.name = "Thanh toán";
                tmp.des = "Thanh toán";
                context.actions!.Add(tmp);
            }
            action = context.actions!.Where(s => s.id.CompareTo("HUYBAN") == 0 && s.isdeleted == false).FirstOrDefault();

            if (action == null)
            {
                SqlAction tmp = new SqlAction();
                tmp.id = "HUYBAN";
                tmp.name = "Hủy bàn";
                tmp.des = "Hủy bàn";
                context.actions!.Add(tmp);
            }
            action = context.actions!.Where(s => s.id.CompareTo("CHUYENBAN") == 0 && s.isdeleted == false).FirstOrDefault();

            if (action == null)
            {
                SqlAction tmp = new SqlAction();
                tmp.id = "CHUYENBAN";
                tmp.name = "Chuyển bàn";
                tmp.des = "Chuyển bàn";
                context.actions!.Add(tmp);
            }

            await context.SaveChangesAsync();
            return Ok(context.actions!.ToList());
        }

        [HttpGet]
        [Route("init-role")]
        public async Task<IActionResult> initRole()
        {
            SqlRole? role = context.roles!.Where(s => s.id.CompareTo("ADMIN") == 0 && s.isdeleted == false).FirstOrDefault();
            if (role == null)
            {
                SqlRole tmp = new SqlRole();
                tmp.id = "ADMIN";
                tmp.name = "Admin";
                tmp.des = "Admin";
                context.roles!.Add(tmp);
            }

            role = context.roles!.Where(s => s.id.CompareTo("MANAGER") == 0 && s.isdeleted == false).FirstOrDefault();
            if (role == null)
            {
                SqlRole tmp = new SqlRole();
                tmp.id = "MANAGER";
                tmp.name = "Quản lý";
                tmp.des = "Quản lý";
                context.roles!.Add(tmp);
            }

            role = context.roles!.Where(s => s.id.CompareTo("STAFF") == 0 && s.isdeleted == false).FirstOrDefault();
            if (role == null)
            {
                SqlRole tmp = new SqlRole();
                tmp.id = "STAFF";
                tmp.name = "Nhân viên";
                tmp.des = "Nhân viên";
                context.roles!.Add(tmp);
            }

            await context.SaveChangesAsync();
            return Ok(context.roles!.ToList());
        }

        [HttpGet]
        [Route("init-user")]
        public async Task<IActionResult> initUser()
        {
            SqlUser? user = context.users!.Where(s => s.username.CompareTo("admin") == 0 && s.isdeleted == false).FirstOrDefault();
            if (user == null)
            {
                SqlUser tmp = new SqlUser();
                tmp.id = DateTime.Now.Ticks;
                tmp.username = "admin";
                tmp.password = "123456";
                tmp.email = "admin";
                tmp.phone = "0123456789";
                tmp.address = "admin";
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlRole? role = context.roles!.Where(s => s.id.CompareTo("ADMIN") == 0 && s.isdeleted == false).FirstOrDefault();
                if (role != null)
                {
                    tmp.role = role;
                }

                context.users!.Add(tmp);
            }

            for (int i = 1; i <= 4; i++)
            {
                string index = i.ToString();
                user = context.users!.Where(s => s.username.CompareTo("quanly" + index) == 0 && s.isdeleted == false).FirstOrDefault();
                if (user == null)
                {
                    SqlUser tmp = new SqlUser();
                    tmp.id = DateTime.Now.Ticks;
                    tmp.username = "quanly" + index;
                    tmp.password = "123456";
                    tmp.email = "quanly" + index;
                    tmp.phone = "0123456789";
                    tmp.address = "quanly" + index;
                    tmp.createTime = DateTime.Now;
                    tmp.updateTime = DateTime.Now;

                    SqlRole? role = context.roles!.Where(s => s.id.CompareTo("MANAGER") == 0 && s.isdeleted == false).FirstOrDefault();
                    if (role != null)
                    {
                        tmp.role = role;
                    }

                    context.users!.Add(tmp);
                }
            }

            for (int i = 1; i <= 10; i++)
            {
                string index = i.ToString();
                user = context.users!.Where(s => s.username.CompareTo("nhanvien" + index) == 0 && s.isdeleted == false).FirstOrDefault();
                if (user == null)
                {
                    SqlUser tmp = new SqlUser();
                    tmp.id = DateTime.Now.Ticks;
                    tmp.username = "nhanvien" + index;
                    tmp.password = "123456";
                    tmp.email = "nhanvien" + index;
                    tmp.phone = "0123456789";
                    tmp.address = "nhanvien" + index;
                    tmp.createTime = DateTime.Now;
                    tmp.updateTime = DateTime.Now;

                    SqlRole? role = context.roles!.Where(s => s.id.CompareTo("STAFF") == 0 && s.isdeleted == false).FirstOrDefault();
                    if (role != null)
                    {
                        tmp.role = role;
                    }

                    context.users!.Add(tmp);
                }
            }

            await context.SaveChangesAsync();
            List<SqlUser> list = context.users!.Include(s => s.role)
                                        .Select(s => new SqlUser
                                        {
                                            id = s.id,
                                            username = s.username,
                                            email = s.email,
                                            phone = s.phone,
                                            address = s.address,
                                            isdeleted = s.isdeleted,
                                            createTime = s.createTime,
                                            updateTime = s.updateTime,
                                            role = new SqlRole
                                            {
                                                id = s.role!.id,
                                                name = s.role.name,
                                                des = s.role.des,
                                                isdeleted = s.role.isdeleted
                                            }
                                        }).ToList();
            return Ok(list);
        }

        [HttpGet]
        [Route("init-table-status")]
        public async Task<IActionResult> initTableStatus()
        {
            SqlTableStatus? status = context.tableStatus!.Where(s => s.id.CompareTo("BANTRONG") == 0 && s.isdeleted == false).FirstOrDefault();
            if (status == null)
            {
                SqlTableStatus tmp = new SqlTableStatus();
                tmp.id = "BANTRONG";
                tmp.name = "Bàn trống";
                tmp.des = "Bàn trống";
                context.tableStatus!.Add(tmp);
            }

            status = context.tableStatus!.Where(s => s.id.CompareTo("DUOCSUDUNG") == 0 && s.isdeleted == false).FirstOrDefault();
            if (status == null)
            {
                SqlTableStatus tmp = new SqlTableStatus();
                tmp.id = "DUOCSUDUNG";
                tmp.name = "Được sử dụng";
                tmp.des = "Được sử dụng";
                context.tableStatus!.Add(tmp);
            }

            status = context.tableStatus!.Where(s => s.id.CompareTo("DANGSUACHUA") == 0 && s.isdeleted == false).FirstOrDefault();
            if (status == null)
            {
                SqlTableStatus tmp = new SqlTableStatus();
                tmp.id = "DANGSUACHUA";
                tmp.name = "Đang sửa chữa";
                tmp.des = "Đang sửa chữa";
                context.tableStatus!.Add(tmp);
            }

            await context.SaveChangesAsync();
            return Ok(context.tableStatus!.ToList());
        }

        [HttpGet]
        [Route("init-table")]
        public async Task<IActionResult> initTable()
        {
            SqlTableStatus? status = context.tableStatus!.Where(s => s.id.CompareTo("BANTRONG") == 0 && s.isdeleted == false).FirstOrDefault();
            for (int i = 1; i <= 6; i++)
            {
                string index = i.ToString();
                SqlTable? table = context.tables!.Where(s => s.name.CompareTo("A.0" + index) == 0 && s.isdeleted == false).FirstOrDefault();
                if (table == null)
                {
                    SqlTable tmp = new SqlTable();
                    tmp.id = DateTime.Now.Ticks;
                    tmp.name = "A.0" + index;
                    tmp.des = "Bàn A.0" + index;
                    tmp.customer_code = "";
                    tmp.createTime = DateTime.Now;
                    tmp.updateTime = DateTime.Now;

                    if (status != null)
                    {
                        tmp.status = status;
                    }

                    context.tables!.Add(tmp);
                }

                table = context.tables!.Where(s => s.name.CompareTo("B.0" + index) == 0 && s.isdeleted == false).FirstOrDefault();
                if (table == null)
                {
                    SqlTable tmp = new SqlTable();
                    tmp.id = DateTime.Now.Ticks;
                    tmp.name = "B.0" + index;
                    tmp.des = "Bàn B.0" + index;
                    tmp.customer_code = "";
                    tmp.createTime = DateTime.Now;
                    tmp.updateTime = DateTime.Now;

                    if (status != null)
                    {
                        tmp.status = status;
                    }

                    context.tables!.Add(tmp);
                }

                table = context.tables!.Where(s => s.name.CompareTo("C.0" + index) == 0 && s.isdeleted == false).FirstOrDefault();
                if (table == null)
                {
                    SqlTable tmp = new SqlTable();
                    tmp.id = DateTime.Now.Ticks;
                    tmp.name = "C.0" + index;
                    tmp.des = "Bàn C.0" + index;
                    tmp.customer_code = "";
                    tmp.createTime = DateTime.Now;
                    tmp.updateTime = DateTime.Now;

                    if (status != null)
                    {
                        tmp.status = status;
                    }

                    context.tables!.Add(tmp);
                }

                table = context.tables!.Where(s => s.name.CompareTo("D.0" + index) == 0 && s.isdeleted == false).FirstOrDefault();
                if (table == null)
                {
                    SqlTable tmp = new SqlTable();
                    tmp.id = DateTime.Now.Ticks;
                    tmp.name = "D.0" + index;
                    tmp.des = "Bàn D.0" + index;
                    tmp.customer_code = "";
                    tmp.createTime = DateTime.Now;
                    tmp.updateTime = DateTime.Now;

                    if (status != null)
                    {
                        tmp.status = status;
                    }

                    context.tables!.Add(tmp);
                }
            }

            await context.SaveChangesAsync();
            List<SqlTable> list = context.tables!.Include(s => s.status)
                                                 .Select(s => new SqlTable
                                                 {
                                                     id = s.id,
                                                     des = s.des,
                                                     isdeleted = s.isdeleted,
                                                     customer_code = s.customer_code,
                                                     createTime = s.createTime,
                                                     updateTime = s.updateTime,
                                                     status = new SqlTableStatus
                                                     {
                                                         id = s.status!.id,
                                                         name = s.status!.name,
                                                         des = s.status.des,
                                                         isdeleted = s.status.isdeleted
                                                     }
                                                 }).ToList();
            return Ok(list);
        }

        [HttpGet]
        [Route("init-category")]
        public async Task<IActionResult> initCategory()
        {
            SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("MONCHINH") == 0 && s.isdeleted == false).FirstOrDefault();
            if (category == null)
            {
                SqlCategory tmp = new SqlCategory();
                tmp.id = DateTime.Now.Ticks;
                tmp.name = "Món chính";
                tmp.des = "MONCHINH";
                context.categories!.Add(tmp);
            }

            category = context.categories!.Where(s => s.des.CompareTo("MONPHU") == 0 && s.isdeleted == false).FirstOrDefault();
            if (category == null)
            {
                SqlCategory tmp = new SqlCategory();
                tmp.id = DateTime.Now.Ticks;
                tmp.name = "Món phụ";
                tmp.des = "MONPHU";
                context.categories!.Add(tmp);
            }

            category = context.categories!.Where(s => s.des.CompareTo("TRANGMIENG") == 0 && s.isdeleted == false).FirstOrDefault();
            if (category == null)
            {
                SqlCategory tmp = new SqlCategory();
                tmp.id = DateTime.Now.Ticks;
                tmp.name = "Tráng miệng";
                tmp.des = "TRANGMIENG";
                context.categories!.Add(tmp);
            }

            category = context.categories!.Where(s => s.des.CompareTo("DOUONG") == 0 && s.isdeleted == false).FirstOrDefault();
            if (category == null)
            {
                SqlCategory tmp = new SqlCategory();
                tmp.id = DateTime.Now.Ticks;
                tmp.name = "Đồ uống";
                tmp.des = "DOUONG";
                context.categories!.Add(tmp);
            }

            await context.SaveChangesAsync();
            return Ok(context.categories!.ToList());
        }

        [HttpGet]
        [Route("init-menu-status")]
        public async Task<IActionResult> initMenuStatus()
        {
            SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
            if (status == null)
            {
                SqlMenuItemStatus tmp = new SqlMenuItemStatus();
                tmp.id = "SANSANG";
                tmp.name = "Món ăn sẵn sàng";
                tmp.des = "Món ăn sẵn sàng";
                context.menuItemStatus!.Add(tmp);
            }

            status = context.menuItemStatus!.Where(s => s.id.CompareTo("TAMHET") == 0 && s.isdeleted == false).FirstOrDefault();
            if (status == null)
            {
                SqlMenuItemStatus tmp = new SqlMenuItemStatus();
                tmp.id = "TAMHET";
                tmp.name = "Món ăn tạm hết";
                tmp.des = "Món ăn tạm hết";
                context.menuItemStatus!.Add(tmp);
            }

            status = context.menuItemStatus!.Where(s => s.id.CompareTo("SAPRAMAT") == 0 && s.isdeleted == false).FirstOrDefault();
            if (status == null)
            {
                SqlMenuItemStatus tmp = new SqlMenuItemStatus();
                tmp.id = "SAPRAMAT";
                tmp.name = "Sắp ra mắt";
                tmp.des = "Sắp ra mắt";
                context.menuItemStatus!.Add(tmp);
            }

            await context.SaveChangesAsync();
            return Ok(context.menuItemStatus!.ToList());
        }

        [HttpGet]
        [Route("init-menu")]
        public async Task<IActionResult> initMenu()
        {
            // ********************************** MÓN CHÍNH *********************************
            SqlMenuItem? menu = context.menuItems!.Where(s => s.code.CompareTo("BOHAMSOTVANG") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "BOHAMSOTVANG";
                tmp.name = "Bò hầm sốt vang";
                tmp.description = "Bò Hầm Sốt Vang - thịt bò mềm mại, hấp thụ hương vị độc đáo của sốt vang đỏ, kèm theo rau củ tươi ngon. Gia vị hài hòa, tạo nên trải nghiệm ẩm thực đặc sắc, hứa hẹn làm hài lòng khẩu vị của bạn.";
                tmp.ingredients = "Thịt bò mềm mại được cắt thành miếng vừa ăn, hầm trong nước cơ bản, kết hợp với sốt vang đỏ đặc trưng tạo nên hương vị độc đáo. Rau củ như cà rốt, khoai tây, nấm và hành tây được thêm vào để tăng thêm sự dinh dưỡng và hấp dẫn";
                tmp.imagePath = "";
                tmp.price = 100000;
                tmp.profit = 80000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("MONCHINH") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.des.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("CATAITUONGCHIENGION") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "CATAITUONGCHIENGION";
                tmp.name = "Cá tai tượng chiên gòn";
                tmp.description = "Món Cá Tai Tượng Chiên Giòn là một trải nghiệm ẩm thực độc đáo tại nhà hàng chúng tôi. Những chiếc cá tai tượng tươi ngon được chiên giòn đến vàng óng, tạo nên lớp vỏ giòn tan kết hợp với bên trong mềm mại và thơm ngon";
                tmp.ingredients = "Cá tai tượng tươi ngon - Bột chiên giòn - Gia vị ẩm thực đặc biệt - Rau sống tươi mát làm điểm nhấn";
                tmp.imagePath = "";
                tmp.price = 500000;
                tmp.profit = 120000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("MONCHINH") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("BEEFSTEAKTIEUDEN") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "BEEFSTEAKTIEUDEN";
                tmp.name = "Beefsteak sốt tiêu đen";
                tmp.description = "Món Beefsteak Sốt Tiêu Đen tại nhà hàng chúng tôi là một sự kết hợp tuyệt vời giữa thịt bò tươi ngon, sốt tiêu đen hấp dẫn, trứng pate mềm mại và khoai nghiền thơm béo. Thịt bò được nướng vừa chín tới, giữ nguyên độ mềm mại và tinh tế, tạo nên sự phong phú trong khẩu vị.";
                tmp.ingredients = "Thịt bò Wagyu A5 - Sốt tiêu đen đặc biệt - Trứng pate mềm mại - Khoai nghiền thơm béo - Gia vị tinh tế - Rau sống tươi mát làm điểm nhấn";
                tmp.imagePath = "";
                tmp.price = 300000;
                tmp.profit = 100000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("MONCHINH") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("TOMSOTMAYONESE") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "TOMSOTMAYONESE";
                tmp.name = "Tôm sốt mayonese trái thơm";
                tmp.description = "Món Tôm Sốt Mayonnaise Trái Thơm tại nhà hàng chúng tôi là một sự kết hợp tinh tế giữa hương vị tươi ngon của tôm biển và sự thơm ngon của trái cây thơm. Những con tôm tươi ngon được ướp sốt mayonnaise, tạo nên lớp vỏ hấp dẫn, kết hợp với trái thơm tạo nên sự phong phú và tươi mới đặc biệt.";
                tmp.ingredients = "Tôm biển tươi ngon - Sốt mayonnaise trứ danh - Trái thơm tươi mát - Gia vị tinh tế - Rau sống tươi mát làm điểm nhấn";
                tmp.imagePath = "";
                tmp.price = 600000;
                tmp.profit = 160000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("MONCHINH") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("VITQUAYBACKINH") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "VITQUAYBACKINH";
                tmp.name = "Vịt quay Bắc Kinh";
                tmp.description = "Món Vịt Quay Bắc Kinh tại nhà hàng chúng tôi là một hòa quyện tuyệt vời giữa vị béo ngậy của thịt vịt và hương vị đặc trưng của phương pháp quay Bắc Kinh. Sự giữ được vị ngon của thịt vịt cùng với lớp da giòn tan là điểm đặc biệt của món ăn này.";
                tmp.ingredients = "Thịt vịt chọn lựa - Gia vị ướp đặc biệt theo phong cách Bắc Kinh - Lớp da giòn tan hấp dẫn - Rau sống tươi mát làm điểm nhấn";
                tmp.imagePath = "";
                tmp.price = 1000000;
                tmp.profit = 260000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("MONCHINH") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("LAUTOMYUMHAISAN") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "LAUTOMYUMHAISAN";
                tmp.name = "Lẩu Tom Yum hải sản";
                tmp.description = "Lẩu Tom Yum Hải Sản tại nhà hàng chúng tôi là một hòa quyện tuyệt vời giữa hương vị tươi ngon của hải sản và hương thơm đặc trưng của nước lẩu Tom Yum. Sự kết hợp này tạo nên một bữa ăn ngon miệng và đậm đà, làm hài lòng các thực khách yêu thích ẩm thực Đông Nam Á.";
                tmp.ingredients = "Hải sản đa dạng (tôm, mực, nghêu, cá) - Nước lẩu Tom Yum đậm đà - Gia vị theo công thức truyền thống - Rau sống tươi mát (cà rốt, nấm, hành tây) - Bún hoặc bún gạo (tùy chọn).";
                tmp.imagePath = "";
                tmp.price = 260000;
                tmp.profit = 80000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("MONCHINH") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("CUAHOANGDEHAPBIA") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "CUAHOANGDEHAPBIA";
                tmp.name = "Cua hoàng đế hấp bia";
                tmp.description = "Món Cua Hoàng Đế Hấp Bia không chỉ là một món biểu tượng của hương vị biển cả mà còn là sự hòa quyện tuyệt vời giữa hương thơm độc đáo của bia và vị ngon của cua. Mỗi miếng cua hấp kết hợp hài hòa với hương vị nồng nàn từ bia, mang lại trải nghiệm ẩm thực đặc sắc và sang trọng.";
                tmp.ingredients = "Cua hoàng đế tươi ngon - Bia chất lượng - Gia vị và thảo mộc tự nhiên - Rau sống tươi mát làm điểm nhấn";
                tmp.imagePath = "";
                tmp.price = 1200000;
                tmp.profit = 300000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("MONCHINH") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("HEOSUAQUAYDAGION") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "HEOSUAQUAYDAGION";
                tmp.name = "Heo sửa quay da giòn";
                tmp.description = "Món Heo Sữa Quay Da Giòn không chỉ là một tác phẩm nghệ thuật ẩm thực mà còn là sự kết hợp tuyệt vời giữa vị thơm ngon của thịt heo sữa và độ giòn của lớp da quay. Thưởng thức món ăn này, thực khách sẽ được trải nghiệm hương vị độc đáo và đầy hấp dẫn.";
                tmp.ingredients = "Thịt heo sữa tươi ngon - Gia vị ướp đặc biệt - Lớp da quay giòn - Rau sống tươi mát làm điểm nhấn";
                tmp.imagePath = "";
                tmp.price = 1000000;
                tmp.profit = 400000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("MONCHINH") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            // ********************************** MÓN PHỤ *********************************
            menu = context.menuItems!.Where(s => s.code.CompareTo("SUNGACHIENNUOCMAM") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "SUNGACHIENNUOCMAM";
                tmp.name = "Sụn gà chiên nước mắm";
                tmp.description = "Sụn Gà Chiên Nước Mắm tại nhà hàng chúng tôi là một món ăn độc đáo, kết hợp giữa sự giòn rụm của sụn gà và hương vị đậm đà của nước mắm. Mỗi miếng sụn gà được chiên giòn tới mức hoàn hảo, tạo nên lớp vỏ hấp dẫn và giữ được hương vị tinh tế của sụn gà.";
                tmp.ingredients = "Sụn gà tươi ngon - Nước mắm chất lượng - Bột chiên giòn - Gia vị ướp đặc biệt";
                tmp.imagePath = "";
                tmp.price = 60000;
                tmp.profit = 40000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("MONPHU") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("MUCCHIENGION") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "MUCCHIENGION";
                tmp.name = "Mực chiên giòn";
                tmp.description = "Mực Chiên Gòn tại nhà hàng chúng tôi là một sự phối hợp hài hòa giữa sự giòn rụm của mực và hương vị đặc trưng của phương pháp chiên Gòn truyền thống. Mỗi miếng mực được chiên giòn tới mức hoàn hảo, tạo nên lớp vỏ giòn và mực bên trong vẫn giữ được sự mềm mại và thơm ngon.";
                tmp.ingredients = "Mực tươi ngon - Bột chiên giòn - Gia vị ướp đặc biệt - Rau sống tươi mát làm điểm nhấn";
                tmp.imagePath = "";
                tmp.price = 80000;
                tmp.profit = 40000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("MONPHU") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("TOMLANBOT") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "TOMLANBOT";
                tmp.name = "Tôm lăn bột chiên giòn";
                tmp.description = "Tôm Lăn Bột Chiên Giòn tại nhà hàng chúng tôi là một sự kết hợp tuyệt vời giữa sự tươi ngon của tôm biển và vị giòn tan của bột chiên. Mỗi con tôm được lăn đều trong lớp bột chiên giòn, tạo nên một lớp vỏ hấp dẫn, giữ nguyên hương vị ngon và tinh tế của tôm.";
                tmp.ingredients = "Tôm biển tươi ngon - Bột chiên giòn - Gia vị ướp đặc biệt - Rau sống tươi mát làm điểm nhấn";
                tmp.imagePath = "";
                tmp.price = 60000;
                tmp.profit = 40000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("MONPHU") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("COMCHIENHAISAN") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "COMCHIENHAISAN";
                tmp.name = "Sushi lăn bột chiên giòn";
                tmp.description = "Cơm Chiên Hải Sản tại nhà hàng chúng tôi là một tác phẩm nghệ thuật ẩm thực, kết hợp hài hòa giữa hương vị đậm đà của cơm chiên và sự tươi ngon của hải sản. Mỗi hạt cơm được chiên giòn và hòa quyện với hải sản đa dạng, tạo nên một bữa ăn ngon miệng và đa dạng.";
                tmp.ingredients = "Cơm trắng tinh tế - Hải sản đa dạng như tôm, mực, nghêu, cá... - Gia vị chiên nước mắm đặc biệt - Rau sống tươi mát như cà rốt, hành tây, nấm";
                tmp.imagePath = "";
                tmp.price = 100000;
                tmp.profit = 60000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("MONPHU") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("KHOAITAYCHIEN") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "KHOAITAYCHIEN";
                tmp.name = "Khoai Tây Chiên";
                tmp.description = "Khoai Tây Chiên tại nhà hàng chúng tôi là một món ăn giản đơn nhưng vô cùng phổ biến và phục vụ mọi lứa tuổi. Khoai tây được cắt thành từng sợi mảnh, sau đó chiên giòn để tạo nên lớp vỏ hấp dẫn và hương vị thơm ngon.";
                tmp.ingredients = "Khoai tây tươi ngon - Dầu ăn chất lượng - Gia vị muối và tiêu - Sốt tùy chọn (sốt ớt, mayonnaise, ketchup)";
                tmp.imagePath = "";
                tmp.price = 50000;
                tmp.profit = 25000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("MONPHU") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("MICAYHANQUOC") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "MICAYHANQUOC";
                tmp.name = "Mì Cay Hàn Quốc";
                tmp.description = "Mì Cay Hàn Quốc tại nhà hàng chúng tôi là một món ăn thú vị và đậm đà, kết hợp giữa hương vị cay nồng và độ ngon của mì. Mỗi sợi mì được đặt trong nước dùng cay nồng, tạo nên một tác phẩm ẩm thực phản ánh đặc sắc văn hóa ẩm thực Hàn Quốc.";
                tmp.ingredients = "Mì gói Hàn Quốc - Nước dùng cay nồng đặc biệt - Thực phẩm chấm tương ớt Hàn Quốc - Rau sống tươi mát như rau sống, cà rốt, kim chi";
                tmp.imagePath = "";
                tmp.price = 50000;
                tmp.profit = 30000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("MONPHU") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            // ********************************** MÓN PHỤ *********************************
            menu = context.menuItems!.Where(s => s.code.CompareTo("KEMTRAICAY") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "KEMTRAICAY";
                tmp.name = "Kem trái cây";
                tmp.description = "Món Kem Trái Cây là một lựa chọn hoàn hảo cho những ai yêu thích sự kết hợp giữa vị ngọt, tươi mới và nhẹ nhàng. Thưởng thức món ăn này, bạn sẽ được đắm chìm trong hương vị thơm ngon và tinh tế, tạo nên một kết thúc hoàn hảo cho bữa ăn.";
                tmp.ingredients = "Kem mềm mại chất lượng - Trái cây tươi ngon như dâu, lựu, kiwi - Sốt trái cây đặc biệt";
                tmp.imagePath = "";
                tmp.price = 30000;
                tmp.profit = 20000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("TRANGMIENG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("CHEKHUCBACH") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "CHEKHUCBACH";
                tmp.name = "Chè khúc bạch";
                tmp.description = "Món Chè Khúc Bạch là sự hòa quyện của vị ngọt dịu từ nước cốt dừa, vị thơm mát của bánh khúc, và hương vị độc đáo từ hạt sen và đậu phộng rang. Mỗi ngụm chè là một hành trình qua vị giác và mang lại cảm giác thoải mái và ngon miệng cho thực khách.";
                tmp.ingredients = "Bánh khúc trắng mịn - Nước cốt dừa tươi ngon - Đường đen và đường trắng (hoặc mật ong) - Hạt sen và đậu phộng rang";
                tmp.imagePath = "";
                tmp.price = 25000;
                tmp.profit = 20000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("TRANGMIENG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("TRAICAYNHIETDOI") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "TRAICAYNHIETDOI";
                tmp.name = "Trái cây nhiệt đới";
                tmp.description = "Món Trái Cây Nhiệt Đới tại nhà hàng chúng tôi là một tuyển chọn tinh tế của những loại trái cây tươi ngon, mỗi loại đều đem lại hương vị đặc trưng và dinh dưỡng đa dạng. Sự kết hợp này không chỉ là một bữa ăn ngon miệng mà còn là một chuyến phiêu lưu qua hương vị của các quốc gia nhiệt đới.";
                tmp.ingredients = "Xoài chín mọng của vùng nhiệt đới - Dâu tây đỏ rực từ vườn trái cây tự nhiên - Kiwi xanh mướt - Chanh dây chua chua ngọt ngọt - Mâm xôi và mâm cau mọng nước\r\nHạt giống lựu, dẻo thơm";
                tmp.imagePath = "";
                tmp.price = 30000;
                tmp.profit = 20000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("TRANGMIENG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("PANNACOTTACARAMEL") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "PANNACOTTACARAMEL";
                tmp.name = "Panna Cotta Caramel";
                tmp.description = "Món Panna Cotta Caramel của chúng tôi thường được chế biến cầu kỳ, với lớp caramel mượt mà trải đều lên trên cùng của từng chiếc panna cotta. Bạn sẽ cảm nhận được sự hòa quyện tuyệt vời giữa sự ngọt ngào và béo ngậy, tạo nên một hương vị độc đáo và không thể cưỡng. Món tráng miệng này thường được trình bày trong các đồ uống tráng miệng hoặc trên bàn dessert, hứa hẹn làm say đắm vị giác của thực khách.";
                tmp.ingredients = "Kem sữa chất lượng cao - Đường và vani để tăng hương vị - Gelatin để đảm bảo độ đặc của panna cotta - Sốt caramel đặc biệt phủ lên trên cùng - Lá bạc hoặc lá mạ vàng để trang trí";
                tmp.imagePath = "";
                tmp.price = 60000;
                tmp.profit = 20000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("TRANGMIENG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("MOCHITRAICAY") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "MOCHITRAICAY";
                tmp.name = "Mochi Trái Cây";
                tmp.description = "Món Mochi Trái Cây tại nhà hàng chúng tôi là sự kết hợp tuyệt vời giữa hương vị trái cây tươi ngon và độ ngon của lớp bánh mochi mềm mại. Mỗi chiếc mochi nhỏ được chế biến cầu kỳ, mang lại trải nghiệm ẩm thực độc đáo và thú vị.";
                tmp.ingredients = "Bánh mochi mềm mại - Nhân trái cây như dưa lưới, xoài, dâu tây - Bột đậu nành hoặc bột gạo bên ngoài để tạo độ giòn";
                tmp.imagePath = "";
                tmp.price = 50000;
                tmp.profit = 20000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("TRANGMIENG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("TIRAMISU") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "TIRAMISU";
                tmp.name = "Bánh Tiramisu";
                tmp.description = "Món Tiramisu tại nhà hàng chúng tôi là một tác phẩm nghệ thuật ẩm thực, kết hợp hài hòa giữa hương vị cà phê đậm đà, kem phô mai mềm mại và lớp bánh ladyfinger ẩm cách. \"Ánh Tiramisu\" không chỉ là một món tráng miệng thơm ngon mà còn là một trải nghiệm ẩm thực tinh tế.";
                tmp.ingredients = "Bánh ladyfinger hấp dẫn - Cà phê robusta đậm đà - Kem phô mai mềm mại và béo ngậy - Đường và vani để tăng hương vị - Bột cacao hoặc chocolate bột để trang trí";
                tmp.imagePath = "";
                tmp.price = 60000;
                tmp.profit = 20000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("TRANGMIENG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            // ********************************** ĐỒ UỐNG *********************************
            menu = context.menuItems!.Where(s => s.code.CompareTo("CAMVAT") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "CAMVAT";
                tmp.name = "Cam vắt";
                tmp.description = "Món Cam Vắt tại nhà hàng chúng tôi là một lựa chọn tươi mới và bổ dưỡng, tận hưởng hương vị tinh tế và ngon ngọt của cam tươi vắt.";
                tmp.ingredients = "Cam tươi ngon và chín mọng - Đường hoặc mật ong để điều chỉnh độ ngọt (tuỳ chọn) - Đá viên để mát lạnh (tuỳ chọn)";
                tmp.imagePath = "";
                tmp.price = 20000;
                tmp.profit = 10000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("DOUONG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("NUOCEPCHANHDAY") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "NUOCEPCHANHDAY";
                tmp.name = "Nước ép chanh dây";
                tmp.description = "Món Nước Chanh Dây là một lựa chọn kh refreshing và lành mạnh, làm bổ sung năng lượng và vitamin cho cơ thể, đồng thời mang lại trải nghiệm thưởng thức thức uống tinh tế.";
                tmp.ingredients = "Nước cốt chanh tươi ngon - Dây tươi mát và chín mọng - Đường hoặc mật ong để điều chỉnh độ ngọt (tuỳ chọn) - Đá viên để mát lạnh (tuỳ chọn)";
                tmp.imagePath = "";
                tmp.price = 20000;
                tmp.profit = 10000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("DOUONG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("TRATACMATONG") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "TRATACMATONG";
                tmp.name = "Trà tắc mật ong";
                tmp.description = "Món Trà Tắc Mật Ong tại nhà hàng chúng tôi là sự kết hợp tuyệt vời giữa hương vị thơm ngon của trà và vị ngọt của mật ong, cùng sự tươi mới của trái tắc, tạo nên một thức uống ấm áp và bổ dưỡng.";
                tmp.ingredients = "Trà đen chất lượng - Trái tắc tươi ngon, cắt lát hoặc nghiêng dưa hấu - Mật ong tự nhiên - Đá lạnh (tuỳ chọn)";
                tmp.imagePath = "";
                tmp.price = 30000;
                tmp.profit = 10000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("DOUONG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("COCACOLA") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "COCACOLA";
                tmp.name = "Cocacola";
                tmp.description = "Coca-Cola không chỉ là một đồ uống phổ biến và thơm ngon mà còn là nguồn cảm hứng cho nhiều biến thể khác nhau như coca-cola với chanh, coca-cola với đá, hoặc các cocktail phức tạp hơn. Đây là một lựa chọn thưởng thức giải khát và tận hưởng mọi khoảnh khắc.";
                tmp.ingredients = "Chai hoặc lon Coca-Cola lạnh - Đá viên (tuỳ chọn) - Lá bạc hoặc ống hút để trang trí (tuỳ chọn)";
                tmp.imagePath = "";
                tmp.price = 8000;
                tmp.profit = 10000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("DOUONG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("PEPSI") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "PEPSI";
                tmp.name = "Pepsi";
                tmp.description = "Pepsi không chỉ là một đồ uống phổ biến và thơm ngon mà còn là nguồn cảm hứng cho nhiều biến thể khác nhau như Pepsi với chanh, coca-cola với đá, hoặc các cocktail phức tạp hơn. Đây là một lựa chọn thưởng thức giải khát và tận hưởng mọi khoảnh khắc.";
                tmp.ingredients = "Chai hoặc lon Pepsi lạnh - Đá viên (tuỳ chọn) - Lá bạc hoặc ống hút để trang trí (tuỳ chọn)";
                tmp.imagePath = "";
                tmp.price = 8000;
                tmp.profit = 10000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("DOUONG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }

            menu = context.menuItems!.Where(s => s.code.CompareTo("HENEIKEN") == 0 && s.isdeleted == false).FirstOrDefault();
            if (menu == null)
            {
                SqlMenuItem tmp = new SqlMenuItem();
                tmp.id = DateTime.Now.Ticks;
                tmp.code = "HENEIKEN";
                tmp.name = "Bia Heneiken";
                tmp.description = "Heineken mang lại sự kết hợp hài hòa giữa hương vị lạnh mát và sảng khoái của bia Heineken với độ chua ngọt từ cam và chanh tươi. Mỗi giọt nước đều mang lại cảm giác tươi mới và hứng khởi, làm tăng thêm trải nghiệm thưởng thức của bạn.";
                tmp.ingredients = "Chai Heneiken lạnh - Đá viên (tuỳ chọn) - Lá bạc hoặc ống hút để trang trí (tuỳ chọn)";
                tmp.imagePath = "";
                tmp.price = 10000;
                tmp.profit = 12000;
                tmp.isdeleted = false;
                tmp.createTime = DateTime.Now;
                tmp.updateTime = DateTime.Now;

                SqlCategory? category = context.categories!.Where(s => s.des.CompareTo("DOUONG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (category != null)
                {
                    tmp.category = category;
                }

                SqlMenuItemStatus? status = context.menuItemStatus!.Where(s => s.id.CompareTo("SANSANG") == 0 && s.isdeleted == false).FirstOrDefault();
                if (status != null)
                {
                    tmp.status = status;
                }

                context.menuItems!.Add(tmp);
            }


            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
