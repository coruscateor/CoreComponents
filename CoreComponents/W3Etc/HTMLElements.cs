using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.W3Etc
{

    //Element infromation gathered from:

    //https://developer.mozilla.org/en-US/docs/Web/HTML/Element

    public static class HTMLElements
    {

        //a

        public static MultiTagElement a()
        {

            return new MultiTagElement("a");

        }

        public static MultiTagElement abbr()
        {

            return new MultiTagElement("abbr");

        }

        [ObsoleteTag(5)]
        public static MultiTagElement acronym()
        {

            return new MultiTagElement("acronym");

        }

        public static MultiTagElement address()
        {

            return new MultiTagElement("address");
        
        }

        [ObsoleteTag(5)]
        public static MultiTagElement applet()
        {

            return new MultiTagElement("applet");

        }

        public static MultiTagElement area()
        {

            return new MultiTagElement("area");

        }

        [Version(5)]
        public static MultiTagElement article()
        {

            return new MultiTagElement("article");

        }

        [Version(5)]
        public static MultiTagElement aside()
        {

            return new MultiTagElement("aside");

        }

        [Version(5)]
        public static MultiTagElement audio()
        {

            return new MultiTagElement("audio");

        }

        //b

        public static MultiTagElement b()
        {

            return new MultiTagElement("b");

        }

        public static MultiTagElement @base()
        {

            return new MultiTagElement("base");

        }

        [ObsoleteTag(5)]
        public static MultiTagElement basefont()
        {

            return new MultiTagElement("basefont");

        }

        [Version(5)]
        public static MultiTagElement bdi()
        {

            return new MultiTagElement("bdi");

        }

        public static MultiTagElement bdo()
        {

            return new MultiTagElement("bdo");

        }

        [ObsoleteTag(5)]
        public static MultiTagElement bgsound()
        {

            return new MultiTagElement("bgsound");

        }

        [ObsoleteTag(5)]
        public static MultiTagElement big()
        {

            return new MultiTagElement("big");

        }

        [ObsoleteTag(5)]
        public static MultiTagElement blink()
        {

            return new MultiTagElement("blink");

        }
        
        public static MultiTagElement blockquote()
        {

            return new MultiTagElement("blockquote");

        }

        public static MultiTagElement body()
        {

            return new MultiTagElement("body");

        }

        public static SingleTagElement br()
        {

            return new SingleTagElement("br");

        }

        public static MultiTagElement button()
        {

            return new MultiTagElement("button");

        }

        //c

        [Version(5)]
        public static MultiTagElement canvas()
        {

            return new MultiTagElement("canvas");

        }

        public static MultiTagElement caption()
        {

            return new MultiTagElement("caption");

        }

        [ObsoleteTag("5")]
        public static MultiTagElement center()
        {

            return new MultiTagElement("center");

        }

        public static MultiTagElement cite()
        {

            return new MultiTagElement("cite");

        }

        public static MultiTagElement code()
        {

            return new MultiTagElement("code");

        }

        public static MultiTagElement col()
        {

            return new MultiTagElement("col");

        }

        public static MultiTagElement colgroup()
        {

            return new MultiTagElement("colgroup");

        }
        
        public static MultiTagElement content()
        {

            return new MultiTagElement("content");

        }

        //d

        [Version(5)]
        public static MultiTagElement data()
        {

            return new MultiTagElement("data");

        }

        [Version(5)]
        public static MultiTagElement datalist()
        {

            return new MultiTagElement("datalist");

        }

        public static MultiTagElement dd()
        {

            return new MultiTagElement("dd");

        }

        public static MultiTagElement decorator()
        {

            return new MultiTagElement("decorator");

        }

        public static MultiTagElement del()
        {

            return new MultiTagElement("del");

        }

        [Version(5)]
        public static MultiTagElement details()
        {

            return new MultiTagElement("details");

        }

        public static MultiTagElement dfn()
        {

            return new MultiTagElement("dfn");

        }

        [ObsoleteTag(5)]
        public static MultiTagElement dir()
        {

            return new MultiTagElement("dir");

        }

        public static MultiTagElement div()
        {

            return new MultiTagElement("div");

        }

        public static MultiTagElement dl()
        {

            return new MultiTagElement("dl");

        }

        //e

        public static MultiTagElement element()
        {

            return new MultiTagElement("element");

        }

        public static MultiTagElement em()
        {

            return new MultiTagElement("em");

        }

        [Version(5)]
        public static MultiTagElement embed()
        {

            return new MultiTagElement("embed");

        }

        //f

        public static MultiTagElement fieldset()
        {

            return new MultiTagElement("fieldset");

        }

        [Version(5)]
        public static MultiTagElement figcaption()
        {

            return new MultiTagElement("figcaption");

        }

        [Version(5)]
        public static MultiTagElement figurecaption()
        {

            return new MultiTagElement("figurecaption");

        }

        [ObsoleteTag(5)]
        public static MultiTagElement fork()
        {

            return new MultiTagElement("fork");

        }

        [Version(5)]
        public static MultiTagElement footer()
        {

            return new MultiTagElement("footer");

        }

        public static MultiTagElement form()
        {

            return new MultiTagElement("form");

        }

        [ObsoleteTag(5)]
        public static MultiTagElement frame()
        {

            return new MultiTagElement("frame");

        }

        [ObsoleteTag(5)]
        public static MultiTagElement frameset()
        {

            return new MultiTagElement("frameset");

        }

        //h

        public static MultiTagElement h1()
        {

            return new MultiTagElement("h1");

        }

        public static MultiTagElement h2()
        {

            return new MultiTagElement("h2");

        }

        public static MultiTagElement h3()
        {

            return new MultiTagElement("h3");

        }

        public static MultiTagElement h4()
        {

            return new MultiTagElement("h4");

        }

        public static MultiTagElement h5()
        {

            return new MultiTagElement("h5");

        }

        public static MultiTagElement h6()
        {

            return new MultiTagElement("h6");

        }

        public static MultiTagElement head()
        {

            return new MultiTagElement("head");

        }

        [Version(5)]
        public static MultiTagElement header()
        {

            return new MultiTagElement("header");

        }

        [Version(5)]
        [Experimental]
        public static MultiTagElement hgroup()
        {

            return new MultiTagElement("header");

        }

        public static MultiTagElement hr()
        {

            return new MultiTagElement("hr");

        }

        public static MultiTagElement html()
        {

            return new MultiTagElement("html");

        }

        //i

        public static MultiTagElement i()
        {

            return new MultiTagElement("i");

        }

        public static MultiTagElement iframe()
        {

            return new MultiTagElement("iframe");

        }

        public static MultiTagElement img()
        {

            return new MultiTagElement("img");

        }

        public static MultiTagElement input()
        {

            return new MultiTagElement("input");

        }

        public static MultiTagElement ins()
        {

            return new MultiTagElement("ins");

        }

        [ObsoleteTag(5)]
        public static MultiTagElement isindex()
        {

            return new MultiTagElement("isindex");

        }

        //k

        public static MultiTagElement kdb()
        {

            return new MultiTagElement("kdb");

        }

        public static MultiTagElement keygen()
        {

            return new MultiTagElement("keygen");

        }

        //l

        public static MultiTagElement label()
        {

            return new MultiTagElement("label");

        }

        public static MultiTagElement legend()
        {

            return new MultiTagElement("legend");

        }

        public static MultiTagElement li()
        {

            return new MultiTagElement("li");

        }

        public static MultiTagElement link()
        {

            return new MultiTagElement("link");

        }

        [ObsoleteTag(5)]
        public static MultiTagElement listing()
        {

            return new MultiTagElement("listing");

        }

        //m

        [Version(5)]
        public static MultiTagElement main()
        {

            return new MultiTagElement("isindex");

        }

        public static MultiTagElement map()
        {

            return new MultiTagElement("map");

        }

        [Version(5)]
        public static MultiTagElement mark()
        {

            return new MultiTagElement("mark");

        }

        [ObsoleteTag(5)]
        public static MultiTagElement marquee()
        {

            return new MultiTagElement("marquee");

        }

        [Version(5)]
        public static MultiTagElement menu()
        {

            return new MultiTagElement("menu");

        }

        [Version(5)]
        public static MultiTagElement menuitem()
        {

            return new MultiTagElement("menuitem");

        }

        public static MultiTagElement meta()
        {

            return new MultiTagElement("meta");

        }

        public static MultiTagElement meter()
        {

            return new MultiTagElement("meter");

        }

        //n

        [Version(5)]
        public static MultiTagElement nav()
        {

            return new MultiTagElement("nav");

        }

        [ObsoleteTag(5)]
        public static MultiTagElement nobr()
        {

            return new MultiTagElement("nobr");

        }

        [ObsoleteTag(5)]
        public static MultiTagElement noframes()
        {

            return new MultiTagElement("noframes");

        }

        public static MultiTagElement noscript()
        {

            return new MultiTagElement("noscript");

        }

        //o

        public static MultiTagElement @object()
        {

            return new MultiTagElement("object");

        }

        public static MultiTagElement ol()
        {

            return new MultiTagElement("ol");

        }

        public static MultiTagElement optgroup()
        {

            return new MultiTagElement("optgroup");

        }

        public static MultiTagElement option()
        {

            return new MultiTagElement("option");

        }

        [Version(5)]
        public static MultiTagElement output()
        {

            return new MultiTagElement("output");

        }

        //p

        public static MultiTagElement p()
        {

            return new MultiTagElement("p");

        }

        public static MultiTagElement param()
        {

            return new MultiTagElement("param");

        }

        [ObsoleteTag(5)]
        public static MultiTagElement plaintext()
        {

            return new MultiTagElement("plaintext");

        }

        public static MultiTagElement pre()
        {

            return new MultiTagElement("pre");

        }

        [Version(5)]
        public static MultiTagElement progress()
        {

            return new MultiTagElement("progress");

        }

        //q

        public static MultiTagElement q()
        {

            return new MultiTagElement("q");

        }

        //r

        [Version(5)]
        public static MultiTagElement rp()
        {

            return new MultiTagElement("rp");

        }

        [Version(5)]
        public static MultiTagElement rt()
        {

            return new MultiTagElement("rt");

        }

        [Version(5)]
        public static MultiTagElement ruby()
        {

            return new MultiTagElement("ruby");

        }

        //s
        
        public static MultiTagElement s()
        {

            return new MultiTagElement("s");

        }

        public static MultiTagElement samp()
        {

            return new MultiTagElement("samp");

        }

        public static MultiTagElement script()
        {

            return new MultiTagElement("script");

        }

        [Version(5)]
        public static MultiTagElement section()
        {

            return new MultiTagElement("section");

        }

        public static MultiTagElement select()
        {

            return new MultiTagElement("select");

        }

        public static MultiTagElement shadow()
        {

            return new MultiTagElement("shadow");

        }

        public static MultiTagElement small()
        {

            return new MultiTagElement("small");

        }

        [Version(5)]
        public static MultiTagElement source()
        {

            return new MultiTagElement("source");

        }

        [ObsoleteTag(5)]
        public static MultiTagElement spacer()
        {

            return new MultiTagElement("spacer");

        }

        public static MultiTagElement span()
        {

            return new MultiTagElement("span");

        }

        [ObsoleteTag(5)]
        public static MultiTagElement strike()
        {

            return new MultiTagElement("strike");

        }

        public static MultiTagElement strong()
        {

            return new MultiTagElement("strong");

        }

        public static MultiTagElement style()
        {

            return new MultiTagElement("style");

        }

        [Version(5)]
        public static MultiTagElement summary()
        {

            return new MultiTagElement("summary");

        }

        public static MultiTagElement sup()
        {

            return new MultiTagElement("sup");

        }

        //t

        public static MultiTagElement table()
        {

            return new MultiTagElement("table");

        }

        public static MultiTagElement tbody()
        {

            return new MultiTagElement("tbody");

        }

        public static MultiTagElement td()
        {

            return new MultiTagElement("td");

        }

        public static MultiTagElement template()
        {

            return new MultiTagElement("template");

        }

        public static MultiTagElement textarea()
        {

            return new MultiTagElement("textarea");

        }

        public static MultiTagElement tfoot()
        {

            return new MultiTagElement("tfoot");

        }

        public static MultiTagElement th()
        {

            return new MultiTagElement("th");

        }

        public static MultiTagElement thead()
        {

            return new MultiTagElement("thead");

        }

        [Version(5)]
        public static MultiTagElement time()
        {

            return new MultiTagElement("time");

        }

        public static MultiTagElement title()
        {

            return new MultiTagElement("title");

        }

        public static MultiTagElement tr()
        {

            return new MultiTagElement("tr");

        }

        [Version(5)]
        public static MultiTagElement track()
        {

            return new MultiTagElement("track");

        }

        [ObsoleteTag(5)]
        public static MultiTagElement sub()
        {

            return new MultiTagElement("tt");

        }

        //u

        public static MultiTagElement u()
        {

            return new MultiTagElement("u");

        }

        public static MultiTagElement ul()
        {

            return new MultiTagElement("ul");

        }

        //v

        public static MultiTagElement var()
        {

            return new MultiTagElement("var");

        }

        [Version(5)]
        public static MultiTagElement video()
        {

            return new MultiTagElement("video");

        }

        //w

        [Version(5)]
        public static MultiTagElement wbr()
        {

            return new MultiTagElement("wbr");

        }

        //x

        [ObsoleteTag(5)]
        public static MultiTagElement xmp()
        {

            return new MultiTagElement("xmp");

        }

    }

}
