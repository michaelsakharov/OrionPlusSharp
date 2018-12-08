using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Engine.My
{
    internal sealed class MyProject
    {
        
        internal static MyApplication Application
        {
            get
            {
                return MyProject.m_AppObjectProvider.GetInstance;
            }
        }
        
        internal static User User
        {
            get
            {
                return MyProject.m_UserObjectProvider.GetInstance;
            }
        }
        
        internal static MyProject.MyForms Forms
        {
            get
            {
                return MyProject.m_MyFormsObjectProvider.GetInstance;
            }
        }
        
        internal static MyProject.MyWebServices WebServices
        {
            get
            {
                return MyProject.m_MyWebServicesObjectProvider.GetInstance;
            }
        }

        private static readonly MyProject.ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new MyProject.ThreadSafeObjectProvider<MyApplication>();

        private static readonly MyProject.ThreadSafeObjectProvider<User> m_UserObjectProvider = new MyProject.ThreadSafeObjectProvider<User>();

        private static MyProject.ThreadSafeObjectProvider<MyProject.MyForms> m_MyFormsObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyForms>();

        private static readonly MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices> m_MyWebServicesObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices>();
        
        internal sealed class MyForms
        {
            private static T Create__Instance__<T>(T Instance) where T : Form, new()
            {
                bool flag = Instance == null || Instance.IsDisposed;
                if (flag)
                {
                    bool flag2 = MyProject.MyForms.m_FormBeingCreated != null;
                    if (flag2)
                    {
                        bool flag3 = MyProject.MyForms.m_FormBeingCreated.ContainsKey(typeof(T));
                        if (flag3)
                        {
                            throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
                        }
                    }
                    else
                    {
                        MyProject.MyForms.m_FormBeingCreated = new Hashtable();
                    }
                    MyProject.MyForms.m_FormBeingCreated.Add(typeof(T), null);
                    try
                    {
                        return Activator.CreateInstance<T>();
                    }
                    catch (TargetInvocationException ex) when (ex.InnerException != null)
                    {
                        string BetterMessage = Utils.GetResourceString("WinForms_SeeInnerException", new string[]
                        {
                            ex.InnerException.Message
                        });
                        throw new InvalidOperationException(BetterMessage, ex.InnerException);
                    }
                    finally
                    {
                        MyProject.MyForms.m_FormBeingCreated.Remove(typeof(T));
                    }
                }
                return Instance;
            }

            private void Dispose__Instance__<T>(ref T instance) where T : Form
            {
                instance.Dispose();
                instance = default(T);
            }

            public MyForms()
            {
            }

            public override bool Equals(object o)
            {
                return base.Equals(RuntimeHelpers.GetObjectValue(o));
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            internal new Type GetType()
            {
                return typeof(MyProject.MyForms);
            }

            public override string ToString()
            {
                return base.ToString();
            }

            public FrmAnimation FrmAnimation
            {
                get
                {
                    this.m_FrmAnimation = MyProject.MyForms.Create__Instance__<FrmAnimation>(this.m_FrmAnimation);
                    return this.m_FrmAnimation;
                }
                set
                {
                    if (value != this.m_FrmAnimation)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<FrmAnimation>(ref this.m_FrmAnimation);
                    }
                }
            }

            public FrmAutoMapper FrmAutoMapper
            {
                get
                {
                    this.m_FrmAutoMapper = MyProject.MyForms.Create__Instance__<FrmAutoMapper>(this.m_FrmAutoMapper);
                    return this.m_FrmAutoMapper;
                }
                set
                {
                    if (value != this.m_FrmAutoMapper)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<FrmAutoMapper>(ref this.m_FrmAutoMapper);
                    }
                }
            }

            public frmClasses frmClasses
            {
                get
                {
                    this.m_frmClasses = MyProject.MyForms.Create__Instance__<frmClasses>(this.m_frmClasses);
                    return this.m_frmClasses;
                }
                set
                {
                    if (value != this.m_frmClasses)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmClasses>(ref this.m_frmClasses);
                    }
                }
            }

            public frmEvents frmEvents
            {
                get
                {
                    this.m_frmEvents = MyProject.MyForms.Create__Instance__<frmEvents>(this.m_frmEvents);
                    return this.m_frmEvents;
                }
                set
                {
                    if (value != this.m_frmEvents)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmEvents>(ref this.m_frmEvents);
                    }
                }
            }

            public FrmHouse FrmHouse
            {
                get
                {
                    this.m_FrmHouse = MyProject.MyForms.Create__Instance__<FrmHouse>(this.m_FrmHouse);
                    return this.m_FrmHouse;
                }
                set
                {
                    if (value != this.m_FrmHouse)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<FrmHouse>(ref this.m_FrmHouse);
                    }
                }
            }

            public FrmItem FrmItem
            {
                get
                {
                    this.m_FrmItem = MyProject.MyForms.Create__Instance__<FrmItem>(this.m_FrmItem);
                    return this.m_FrmItem;
                }
                set
                {
                    if (value != this.m_FrmItem)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<FrmItem>(ref this.m_FrmItem);
                    }
                }
            }

            public FrmLogin FrmLogin
            {
                get
                {
                    this.m_FrmLogin = MyProject.MyForms.Create__Instance__<FrmLogin>(this.m_FrmLogin);
                    return this.m_FrmLogin;
                }
                set
                {
                    if (value != this.m_FrmLogin)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<FrmLogin>(ref this.m_FrmLogin);
                    }
                }
            }

            public frmMapEditor frmMapEditor
            {
                get
                {
                    this.m_frmMapEditor = MyProject.MyForms.Create__Instance__<frmMapEditor>(this.m_frmMapEditor);
                    return this.m_frmMapEditor;
                }
                set
                {
                    if (value != this.m_frmMapEditor)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmMapEditor>(ref this.m_frmMapEditor);
                    }
                }
            }

            public frmNPC frmNPC
            {
                get
                {
                    this.m_frmNPC = MyProject.MyForms.Create__Instance__<frmNPC>(this.m_frmNPC);
                    return this.m_frmNPC;
                }
                set
                {
                    if (value != this.m_frmNPC)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmNPC>(ref this.m_frmNPC);
                    }
                }
            }

            public frmPet frmPet
            {
                get
                {
                    this.m_frmPet = MyProject.MyForms.Create__Instance__<frmPet>(this.m_frmPet);
                    return this.m_frmPet;
                }
                set
                {
                    if (value != this.m_frmPet)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmPet>(ref this.m_frmPet);
                    }
                }
            }

            public frmProjectile frmProjectile
            {
                get
                {
                    this.m_frmProjectile = MyProject.MyForms.Create__Instance__<frmProjectile>(this.m_frmProjectile);
                    return this.m_frmProjectile;
                }
                set
                {
                    if (value != this.m_frmProjectile)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmProjectile>(ref this.m_frmProjectile);
                    }
                }
            }

            public FrmQuest FrmQuest
            {
                get
                {
                    this.m_FrmQuest = MyProject.MyForms.Create__Instance__<FrmQuest>(this.m_FrmQuest);
                    return this.m_FrmQuest;
                }
                set
                {
                    if (value != this.m_FrmQuest)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<FrmQuest>(ref this.m_FrmQuest);
                    }
                }
            }

            public FrmRecipe FrmRecipe
            {
                get
                {
                    this.m_FrmRecipe = MyProject.MyForms.Create__Instance__<FrmRecipe>(this.m_FrmRecipe);
                    return this.m_FrmRecipe;
                }
                set
                {
                    if (value != this.m_FrmRecipe)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<FrmRecipe>(ref this.m_FrmRecipe);
                    }
                }
            }

            public FrmResource FrmResource
            {
                get
                {
                    this.m_FrmResource = MyProject.MyForms.Create__Instance__<FrmResource>(this.m_FrmResource);
                    return this.m_FrmResource;
                }
                set
                {
                    if (value != this.m_FrmResource)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<FrmResource>(ref this.m_FrmResource);
                    }
                }
            }

            public frmShop frmShop
            {
                get
                {
                    this.m_frmShop = MyProject.MyForms.Create__Instance__<frmShop>(this.m_frmShop);
                    return this.m_frmShop;
                }
                set
                {
                    if (value != this.m_frmShop)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmShop>(ref this.m_frmShop);
                    }
                }
            }

            public frmSkill frmSkill
            {
                get
                {
                    this.m_frmSkill = MyProject.MyForms.Create__Instance__<frmSkill>(this.m_frmSkill);
                    return this.m_frmSkill;
                }
                set
                {
                    if (value != this.m_frmSkill)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmSkill>(ref this.m_frmSkill);
                    }
                }
            }

            public FrmVisualWarp FrmVisualWarp
            {
                get
                {
                    this.m_FrmVisualWarp = MyProject.MyForms.Create__Instance__<FrmVisualWarp>(this.m_FrmVisualWarp);
                    return this.m_FrmVisualWarp;
                }
                set
                {
                    if (value != this.m_FrmVisualWarp)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<FrmVisualWarp>(ref this.m_FrmVisualWarp);
                    }
                }
            }

            private static Hashtable m_FormBeingCreated;

            public FrmAnimation m_FrmAnimation;

            public FrmAutoMapper m_FrmAutoMapper;

            public frmClasses m_frmClasses;

            public frmEvents m_frmEvents;

            public FrmHouse m_FrmHouse;

            public FrmItem m_FrmItem;

            public FrmLogin m_FrmLogin;

            public frmMapEditor m_frmMapEditor;

            public frmNPC m_frmNPC;

            public frmPet m_frmPet;

            public frmProjectile m_frmProjectile;

            public FrmQuest m_FrmQuest;

            public FrmRecipe m_FrmRecipe;

            public FrmResource m_FrmResource;

            public frmShop m_frmShop;

            public frmSkill m_frmSkill;

            public FrmVisualWarp m_FrmVisualWarp;
        }

        internal sealed class MyWebServices
        {
            public override bool Equals(object o)
            {
                return base.Equals(RuntimeHelpers.GetObjectValue(o));
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            internal new Type GetType()
            {
                return typeof(MyProject.MyWebServices);
            }

            public override string ToString()
            {
                return base.ToString();
            }

            private static T Create__Instance__<T>(T instance) where T : new()
            {
                bool flag = instance == null;
                T Create__Instance__;
                if (flag)
                {
                    Create__Instance__ = Activator.CreateInstance<T>();
                }
                else
                {
                    Create__Instance__ = instance;
                }
                return Create__Instance__;
            }

            private void Dispose__Instance__<T>(ref T instance)
            {
                instance = default(T);
            }

            public MyWebServices()
            {
            }
        }
        
        internal sealed class ThreadSafeObjectProvider<T> where T : new()
        {
            internal T GetInstance
            {
                get
                {
                    bool flag = MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue == null;
                    if (flag)
                    {
                        MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue = Activator.CreateInstance<T>();
                    }
                    return MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue;
                }
            }


            private static T m_ThreadStaticValue;
        }
    }
}
