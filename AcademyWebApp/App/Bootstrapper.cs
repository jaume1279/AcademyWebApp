
using Academy.Lib;
using Academy.Lib.Models;
using Common.Lib.Core.Context;
using Common.Lib.DAL.EFCore;
using Common.Lib.Infrastructure;
using System;

namespace AcademyWebApp.App
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {

        }

        public void Init(IDependencyContainer dp, Func<AcademyDbContext> dbContextConst)
        {
            RegisterRepositories(dp, dbContextConst);
        }

        public void RegisterRepositories(IDependencyContainer depCon, Func<AcademyDbContext> dbContextConst)
        {
            var studentRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new EfCoreRepository<Student>(dbContextConst());
            });
            var subjectsRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new EfCoreRepository<Subject>(dbContextConst());
            });



            depCon.Register<IRepository<Student>, EfCoreRepository<Student>>(studentRepoBuilder);

            depCon.Register<IRepository<Subject>, EfCoreRepository<Subject>>(subjectsRepoBuilder);

            //depCon.Register<IRepository<StudentSubject>, EfCoreRepository<StudentSubject>>(studentsubjectsRepoBuilder);

            //depCon.Register<IRepository<Exam>, EfCoreRepository<Exam>>(examsRepoBuilder);

            //depCon.Register<IRepository<StudentExam>, EfCoreRepository<StudentExam>>(studentsExamRepoBuilder);
        }

        //private static AcademyDbContext GetDbConstructor()
        //{
        //    var factory = new AcademyContextFactory();
        //    return factory.CreateDbContext(null);
        //}
    }
}
