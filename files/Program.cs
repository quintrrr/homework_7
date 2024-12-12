namespace files;

internal class Program
{
    public static void Main(string[] args)
    {
        /*Написать программу, содержащую решение следующих задач:
        На совещании у начальства раздавали задачи. Сотрудники фирмы так задолбались, что
        решили, что будут получать задачи только в том случае, если это их прямое руководство.
        Все возмущение началось из‐за того, что бухгалтерия решила автоматизировать себе работу,
        они хотят приходить на работу, нажимать на кнопочку и чтобы все само делалось, а отдел
        информационных технологий должен сделать эту задачу им. Перейдем к иерархии
        сотрудников:
        Главный в конторе Тимур – генеральный директор.
        У Тимура есть подчиненные:
        Финансовый директор – Рашид,
        Директор по автоматизации – О Ильхам.
        Рашид в подчинении держит бухгалтерию. В бухгалтерии главный Лукас.
        О Ильхам в подчинении держит отдел информационных технологий. В отделе
        информационных технологий следующая иерархия: существует начальник, зам.
        начальника и 2 сектора.
        Начальник инф систем – Оркадий
        Зам.начальника – Володя.
        ○ системщики (занимаются сетями). Главный в секторе системщиков: Ильшат,
        Зам: Иваныч, Сотрудники: Илья, Витя, Женя
        ○ разработчики (разработка и сопровождение). Главный секторе разработчиков:
        Сергей, Зам: Ляйсан, Сотрудники: Марат, Дина , Ильдар, Антон.
        Таким образом, Дина, Марат, Ильдар, Антон слушаются Ляйсан, Ляйсан слушается
        только Сергея, Сергей может слушаться Оркадия и Володю. Аналогично и с
        сектором системщиков. Организовать иерархию конторы, создать несколько
        примитивых задач.
        При назначении задач, задача должна иметь признак кому ее дают: системщикам или
        разработчикам или начальству(начальник и зам.начальник отдела), а потом
        
        распределить задачи по сотрудникам. На экране будет следующее: от человека А
        даётся задача «название задачи» человек Б. И надо вывести берет человек задачу или
        нет.*/
        Console.WriteLine("Упражнение 1");
        var timur = new Employee("Тимур", "Генеральный директор", Department.Начальство);

        var rashid = new Employee("Рашид", "Финансовый директор", Department.Начальство);
        timur.Subordinates.Add(rashid);

        var lukas = new Employee("Лукас", "Главный бухгалтер", Department.Бухгалтерия);
        rashid.Subordinates.Add(lukas);

        var oIlham = new Employee("О Ильхам", "Директор по автоматизации", Department.Начальство);
        timur.Subordinates.Add(oIlham);

        var orkadiy = new Employee("Оркадий", "Начальник отдела ИТ", Department.Начальство);
        oIlham.Subordinates.Add(orkadiy);

        var volodya = new Employee("Володя", "Зам начальника отдела ИТ", Department.Начальство);
        orkadiy.Subordinates.Add(volodya);

        var sergey = new Employee("Сергей", "Главный разработчик", Department.Разработчики);
        volodya.Subordinates.Add(sergey);
        orkadiy.Subordinates.Add(sergey);

        var ilshat = new Employee("Ильшат", "Главный системщик", Department.Системщики);
        volodya.Subordinates.Add(ilshat);
        orkadiy.Subordinates.Add(ilshat);

        var liaysan = new Employee("Ляйсан", "Зам главного разработчика", Department.Разработчики);
        sergey.Subordinates.Add(liaysan);

        var ivanich = new Employee("Иваныч", "Зам главного системщика", Department.Системщики);
        ilshat.Subordinates.Add(ivanich);

        var marat = new Employee("Марат", "Разработчик", Department.Разработчики);
        var dina = new Employee("Дина", "Разработчик", Department.Разработчики);
        var eldar = new Employee("Эльдар", "Разработчик", Department.Разработчики);
        var anton = new Employee("Антон", "Разработчик", Department.Разработчики);
        liaysan.Subordinates.Add(dina);
        liaysan.Subordinates.Add(eldar);
        liaysan.Subordinates.Add(anton);
        liaysan.Subordinates.Add(marat);

        var ilya = new Employee("Илья", "Системщик", Department.Системщики);
        var vitya = new Employee("Витя", "Системщик", Department.Системщики);
        var zhenya = new Employee("Женя", "Системщик", Department.Системщики);
        ivanich.Subordinates.Add(zhenya);
        ivanich.Subordinates.Add(vitya);
        ivanich.Subordinates.Add(ilya);

        var task1 = new Task("Автоматизация отчетности", Department.Начальство);
        var task2 = new Task("Настройка сети для нового офиса", Department.Системщики);
        var task3 = new Task("Разработка клиентского портала", Department.Разработчики);
        var task4 = new Task("Подготовка финансового отчета за квартал", Department.Бухгалтерия);
        var task5 = new Task("Обновление документации отдела", Department.Разработчики);
        var task6 = new Task("Разработка нового модуля CRM", Department.Разработчики);
        var task7 = new Task("Проверка безопасности сети", Department.Системщики);
        var task8 = new Task("Подготовка презентации для инвесторов", Department.Бухгалтерия);
        var task9 = new Task("Настройка серверного оборудования", Department.Системщики);
        var task10 = new Task("Создание внутреннего портала для сотрудников", Department.Начальство);

        timur.assignTask(task1, oIlham);
        orkadiy.assignTask(task2, ilshat);
        liaysan.assignTask(task3, eldar);
        rashid.assignTask(task4, lukas);
        ivanich.assignTask(task5, vitya);
        volodya.assignTask(task6, ilshat);
        sergey.assignTask(task7, liaysan);
        oIlham.assignTask(task8, lukas);
        orkadiy.assignTask(task9, ivanich);
        marat.assignTask(task10, timur);
    }
}