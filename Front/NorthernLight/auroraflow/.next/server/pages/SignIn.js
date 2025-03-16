"use strict";(()=>{var e={};e.id=358,e.ids=[220,358],e.modules={237:(e,t)=>{Object.defineProperty(t,"A",{enumerable:!0,get:function(){return r}});var r=function(e){return e.PAGES="PAGES",e.PAGES_API="PAGES_API",e.APP_PAGE="APP_PAGE",e.APP_ROUTE="APP_ROUTE",e.IMAGE="IMAGE",e}({})},361:e=>{e.exports=require("next/dist/compiled/next-server/pages.runtime.prod.js")},1402:(e,t,r)=>{r.a(e,async(e,n)=>{try{r.d(t,{U:()=>p});var i=r(8732),o=r(2015),a=r(2770),s=r.n(a),l=r(1570),d=r(7843),c=e([d]);d=(c.then?(await c)():c)[0];let f=s().button`
  background: transparent;
  border: none;
  color: ${({theme:e})=>e.text};
  cursor: pointer;
  font-size: 1.25rem;
  padding: 0.5rem;
  display: flex;
  align-items: center;
  justify-content: center;
  transition: color 0.2s ease;
  
  &:hover {
    color: ${({theme:e})=>e.primary};
  }
`,p=()=>{let{theme:e,toggleTheme:t}=(0,o.useContext)(l.D),{t:r}=(0,d.useTranslation)();return(0,i.jsx)(f,{onClick:t,"aria-label":r("header.darkMode"),children:e.isDark?"☀️":"\uD83C\uDF19"})};n()}catch(e){n(e)}})},1413:(e,t)=>{Object.defineProperty(t,"M",{enumerable:!0,get:function(){return function e(t,r){return r in t?t[r]:"then"in t&&"function"==typeof t.then?t.then(t=>e(t,r)):"function"==typeof t&&"default"===r?t:void 0}}})},1570:(e,t,r)=>{r.d(t,{D:()=>i}),r(8732);var n=r(2015);r(2770);let i=(0,n.createContext)({theme:{primary:"#7c3aed",secondary:"#3b82f6",background:"linear-gradient(135deg, rgba(255,255,255,0.9) 0%, rgba(249,250,251,0.95) 100%)",cardBackground:"#f9fafb",text:"#111827",inputBorder:"#d1d5db",inputBackground:"#ffffff",buttonText:"#ffffff",isDark:!1},toggleTheme:()=>{}})},1773:(e,t,r)=>{r.a(e,async(e,n)=>{try{r.r(t),r.d(t,{config:()=>m,default:()=>g,getServerSideProps:()=>x,getStaticPaths:()=>u,getStaticProps:()=>h,reportWebVitals:()=>b,routeModule:()=>P,unstable_getServerProps:()=>v,unstable_getServerSideProps:()=>L,unstable_getStaticParams:()=>w,unstable_getStaticPaths:()=>y,unstable_getStaticProps:()=>j});var i=r(3885),o=r(237),a=r(1413),s=r(8548),l=r.n(s),d=r(9380),c=r.n(d),f=r(3259),p=e([f]);f=(p.then?(await p)():p)[0];let g=(0,a.M)(f,"default"),h=(0,a.M)(f,"getStaticProps"),u=(0,a.M)(f,"getStaticPaths"),x=(0,a.M)(f,"getServerSideProps"),m=(0,a.M)(f,"config"),b=(0,a.M)(f,"reportWebVitals"),j=(0,a.M)(f,"unstable_getStaticProps"),y=(0,a.M)(f,"unstable_getStaticPaths"),w=(0,a.M)(f,"unstable_getStaticParams"),v=(0,a.M)(f,"unstable_getServerProps"),L=(0,a.M)(f,"unstable_getServerSideProps"),P=new i.PagesRouteModule({definition:{kind:o.A.PAGES,page:"/SignIn",pathname:"/SignIn",bundlePath:"",filename:""},components:{App:c(),Document:l()},userland:f});n()}catch(e){n(e)}})},2015:e=>{e.exports=require("react")},2770:e=>{e.exports=require("styled-components")},3259:(e,t,r)=>{r.a(e,async(e,n)=>{try{r.r(t),r.d(t,{default:()=>I});var i=r(8732),o=r(2015),a=r(2770),s=r.n(a),l=r(7843),d=r(1402),c=r(5310),f=e([l,d,c]);[l,d,c]=f.then?(await f)():f;let p=s().div`
  display: flex;
  flex-direction: column;
  min-height: 100vh;
  background-color: ${({theme:e})=>e.background};
  color: ${({theme:e})=>e.text};
  transition: background-color 0.2s ease, color 0.2s ease;
`,g=s().header`
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1rem 2rem;
`,h=s().h1`
  color: ${({theme:e})=>e.primary};
  font-size: 1.5rem;
  font-weight: bold;
  margin: 0;
  background: linear-gradient(to right, ${({theme:e})=>e.primary}, ${({theme:e})=>e.secondary});
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
`,u=s().div`
  display: flex;
  align-items: center;
`,x=s().main`
  flex: 1;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 2rem;
  margin-top: -5vh; /* Move the content up by 5% of viewport height */
`,m=s().div`
  background-color: ${({theme:e})=>e.cardBackground};
  border-radius: 0.75rem;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  padding: 2.5rem;
  width: 100%;
  max-width: 28rem;
  transition: background-color 0.2s ease;
`,b=s().h2`
  color: ${({theme:e})=>e.text};
  font-size: 1.5rem;
  font-weight: 600;
  margin-bottom: 1.5rem;
  text-align: center;
`,j=s().form`
  display: flex;
  flex-direction: column;
  gap: 1.25rem;
`,y=s().div`
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
`,w=s().label`
  color: ${({theme:e})=>e.text};
  font-size: 0.875rem;
  font-weight: 500;
`,v=s().div`
  position: relative;
`,L=s().input`
  background-color: ${({theme:e})=>e.inputBackground};
  border: 1px solid ${({theme:e})=>e.inputBorder};
  border-radius: 0.375rem;
  color: ${({theme:e})=>e.text};
  font-size: 1rem;
  padding: 0.75rem 1rem;
  width: 100%;
  transition: border-color 0.2s ease, background-color 0.2s ease;
  
  &:focus {
    border-color: ${({theme:e})=>e.primary};
    outline: none;
  }
  
  &::placeholder {
    color: #9ca3af;
  }
`,P=s().button`
  background: transparent;
  border: none;
  color: ${({theme:e})=>e.text};
  cursor: pointer;
  position: absolute;
  right: 1rem;
  top: 50%;
  transform: translateY(-50%);
`,k=s().a`
  color: ${({theme:e})=>e.primary};
  font-size: 0.75rem;
  text-decoration: none;
  display: block;
  text-align: right;
  margin-top: 0.5rem;
  
  &:hover {
    text-decoration: underline;
  }
`,$=s().button`
  background: linear-gradient(to right, ${({theme:e})=>e.primary}, ${({theme:e})=>e.secondary});
  border: none;
  border-radius: 0.375rem;
  color: ${({theme:e})=>e.buttonText};
  cursor: pointer;
  font-size: 1rem;
  font-weight: 500;
  margin-top: 0.5rem;
  padding: 0.75rem;
  transition: opacity 0.2s ease;
  
  &:hover {
    opacity: 0.9;
  }
`,S=s().div`
  display: flex;
  align-items: center;
  margin: 1.5rem 0;
  
  &::before, &::after {
    content: '';
    flex: 1;
    border-bottom: 1px solid ${({theme:e})=>e.inputBorder};
  }
  
  span {
    color: ${({theme:e})=>e.text};
    font-size: 0.875rem;
    padding: 0 1rem;
  }
`,M=s().button`
  background-color: white;
  border: 1px solid #d1d5db;
  border-radius: 0.375rem;
  color: #4b5563;
  cursor: pointer;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 1rem;
  font-weight: 500;
  gap: 0.75rem;
  padding: 0.75rem;
  transition: background-color 0.2s ease;
  
  &:hover {
    background-color: #f9fafb;
  }
  
  svg {
    height: 1.5rem;
    width: 1.5rem;
  }
`,A=s().p`
  color: ${({theme:e})=>e.text};
  font-size: 0.875rem;
  margin-top: 1.5rem;
  text-align: center;
  
  a {
    color: ${({theme:e})=>e.primary};
    font-weight: 500;
    text-decoration: none;
    
    &:hover {
      text-decoration: underline;
    }
  }
`,I=()=>{let[e,t]=(0,o.useState)(!1),{t:r}=(0,l.useTranslation)();return(0,i.jsxs)(p,{children:[(0,i.jsxs)(g,{children:[(0,i.jsx)(h,{children:"AuroraFlow"}),(0,i.jsxs)(u,{children:[(0,i.jsx)(d.U,{}),(0,i.jsx)(c.G,{})]})]}),(0,i.jsx)(x,{children:(0,i.jsxs)(m,{children:[(0,i.jsx)(b,{children:r("signIn.title")}),(0,i.jsxs)(j,{onSubmit:e=>{e.preventDefault()},children:[(0,i.jsxs)(y,{children:[(0,i.jsx)(w,{htmlFor:"email",children:r("signIn.email")}),(0,i.jsx)(L,{id:"email",type:"email",placeholder:"example@email.com",required:!0})]}),(0,i.jsxs)(y,{children:[(0,i.jsx)(w,{htmlFor:"password",children:r("signIn.password")}),(0,i.jsxs)(v,{children:[(0,i.jsx)(L,{id:"password",type:e?"text":"password",placeholder:"••••••••",required:!0}),(0,i.jsx)(P,{type:"button",onClick:()=>{t(!e)},"aria-label":e?"Hide password":"Show password",children:e?"\uD83D\uDC41️":"\uD83D\uDC41️‍\uD83D\uDDE8️"})]}),(0,i.jsx)(k,{href:"#",children:r("signIn.forgotPassword")})]}),(0,i.jsx)($,{type:"submit",children:r("signIn.signInButton")})]}),(0,i.jsx)(S,{children:(0,i.jsx)("span",{children:"OR"})}),(0,i.jsxs)(M,{type:"button",children:[(0,i.jsxs)("svg",{viewBox:"0 0 24 24",children:[(0,i.jsx)("path",{fill:"#4285F4",d:"M22.56 12.25c0-.78-.07-1.53-.2-2.25H12v4.26h5.92c-.26 1.37-1.04 2.53-2.21 3.31v2.77h3.57c2.08-1.92 3.28-4.74 3.28-8.09z"}),(0,i.jsx)("path",{fill:"#34A853",d:"M12 23c2.97 0 5.46-.98 7.28-2.66l-3.57-2.77c-.98.66-2.23 1.06-3.71 1.06-2.86 0-5.29-1.93-6.16-4.53H2.18v2.84C3.99 20.53 7.7 23 12 23z"}),(0,i.jsx)("path",{fill:"#FBBC05",d:"M5.84 14.09c-.22-.66-.35-1.36-.35-2.09s.13-1.43.35-2.09V7.07H2.18C1.43 8.55 1 10.22 1 12s.43 3.45 1.18 4.93l2.85-2.22.81-.62z"}),(0,i.jsx)("path",{fill:"#EA4335",d:"M12 5.38c1.62 0 3.06.56 4.21 1.64l3.15-3.15C17.45 2.09 14.97 1 12 1 7.7 1 3.99 3.47 2.18 7.07l3.66 2.84c.87-2.6 3.3-4.53 6.16-4.53z"})]}),r("signIn.signInWithGoogle")]}),(0,i.jsx)(A,{children:(0,i.jsx)("a",{href:"#",children:r("signIn.dontHaveAccount")})})]})})]})};n()}catch(e){n(e)}})},3873:e=>{e.exports=require("path")},5310:(e,t,r)=>{r.a(e,async(e,n)=>{try{r.d(t,{G:()=>b});var i=r(8732),o=r(2015),a=r.n(o),s=r(2770),l=r.n(s),d=r(7843),c=e([d]);d=(c.then?(await c)():c)[0];let f=l().div`
  position: relative;
  margin-left: 1rem;
`,p=l().button`
  background-color: transparent;
  border: 1px solid ${({theme:e})=>e.inputBorder};
  border-radius: 0.375rem;
  color: ${({theme:e})=>e.text};
  cursor: pointer;
  display: flex;
  align-items: center;
  font-size: 0.79rem;
  padding: 0.5rem 0.75rem;
  transition: border-color 0.2s ease;
  
  &:hover {
    border-color: ${({theme:e})=>e.primary};
  }
`,g=l().div`
  position: absolute;
  top: 100%;
  right: 0;
  width: max-content;
  min-width: 100px;
  background-color: ${({theme:e})=>e.cardBackground};
  border: 1px solid ${({theme:e})=>e.inputBorder};
  border-radius: 0.375rem;
  margin-top: 0.25rem;
  display: ${e=>e.$isOpen?"block":"none"};
  z-index: 10;
  overflow: hidden;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
`,h=l().button`
  width: 100%;
  text-align: left;
  padding: 0.5rem 0.75rem;
  border: none;
  background-color: transparent;
  color: ${({theme:e})=>e.text};
  cursor: pointer;
  display: flex;
  align-items: center;
  font-size: 0.79rem;
  
  &:hover {
    background-color: ${({theme:e})=>e.background};
  }
`,u=l().span`
  display: flex;
  align-items: center;
  justify-content: center;
  width: 20px;
  height: 14px;
  margin-right: 10px;
  
  svg {
    width: 100%;
    height: 100%;
  }
`;l().div`
  display: flex;
  align-items: center;
  width: 100%;
  justify-content: space-between;
`;let x=l().span`
  font-weight: 400;
`,m=[{code:"en",abbr:"ENG",flagIcon:(0,i.jsx)(()=>(0,i.jsxs)("svg",{xmlns:"http://www.w3.org/2000/svg",viewBox:"0 0 1235 650",children:[(0,i.jsx)("rect",{width:"1235",height:"650",fill:"#bf0a30"}),(0,i.jsx)("rect",{width:"1235",height:"50",fill:"#ffffff",y:"50"}),(0,i.jsx)("rect",{width:"1235",height:"50",fill:"#ffffff",y:"150"}),(0,i.jsx)("rect",{width:"1235",height:"50",fill:"#ffffff",y:"250"}),(0,i.jsx)("rect",{width:"1235",height:"50",fill:"#ffffff",y:"350"}),(0,i.jsx)("rect",{width:"1235",height:"50",fill:"#ffffff",y:"450"}),(0,i.jsx)("rect",{width:"1235",height:"50",fill:"#ffffff",y:"550"}),(0,i.jsx)("rect",{width:"494",height:"350",fill:"#002868"}),(0,i.jsxs)("g",{fill:"#ffffff",children:[Array.from({length:5}).map((e,t)=>Array.from({length:6}).map((e,r)=>(0,i.jsx)("circle",{cx:41+82*r,cy:35+70*t,r:"19"},`${t}-${r}`))),Array.from({length:4}).map((e,t)=>Array.from({length:5}).map((e,r)=>(0,i.jsx)("circle",{cx:82+82*r,cy:70+70*t,r:"19"},`extra-${t}-${r}`)))]})]}),{})},{code:"ru",abbr:"RUS",flagIcon:(0,i.jsx)(()=>(0,i.jsxs)("svg",{xmlns:"http://www.w3.org/2000/svg",viewBox:"0 0 9 6",children:[(0,i.jsx)("rect",{fill:"#fff",width:"9",height:"3"}),(0,i.jsx)("rect",{fill:"#d52b1e",y:"3",width:"9",height:"3"}),(0,i.jsx)("rect",{fill:"#0039a6",y:"2",width:"9",height:"2"})]}),{})},{code:"ka",abbr:"GEO",flagIcon:(0,i.jsx)(()=>(0,i.jsxs)("svg",{xmlns:"http://www.w3.org/2000/svg",viewBox:"0 0 300 200",children:[(0,i.jsx)("rect",{width:"300",height:"200",fill:"#fff"}),(0,i.jsx)("path",{d:"M 130,0 L 170,0 L 170,80 L 300,80 L 300,120 L 170,120 L 170,200 L 130,200 L 130,120 L 0,120 L 0,80 L 130,80 Z",fill:"#ff0000"}),(0,i.jsx)("path",{d:"M 50,50 L 80,50 L 80,30 L 100,30 L 100,50 L 130,50 L 130,70 L 100,70 L 100,90 L 80,90 L 80,70 L 50,70 Z",fill:"#ff0000"}),(0,i.jsx)("path",{d:"M 200,50 L 230,50 L 230,30 L 250,30 L 250,50 L 280,50 L 280,70 L 250,70 L 250,90 L 230,90 L 230,70 L 200,70 Z",fill:"#ff0000"}),(0,i.jsx)("path",{d:"M 50,150 L 80,150 L 80,130 L 100,130 L 100,150 L 130,150 L 130,170 L 100,170 L 100,190 L 80,190 L 80,170 L 50,170 Z",fill:"#ff0000"}),(0,i.jsx)("path",{d:"M 200,150 L 230,150 L 230,130 L 250,130 L 250,150 L 280,150 L 280,170 L 250,170 L 250,190 L 230,190 L 230,170 L 200,170 Z",fill:"#ff0000"})]}),{})}],b=()=>{let{i18n:e}=(0,d.useTranslation)(),[t,r]=a().useState(!1),n=t=>{e.changeLanguage(t),r(!1)},o=m.find(t=>t.code===e.language)||m[0];return(0,i.jsxs)(f,{children:[(0,i.jsxs)(p,{onClick:()=>{r(!t)},children:[(0,i.jsx)(u,{children:o.flagIcon}),o.abbr]}),(0,i.jsx)(g,{$isOpen:t,children:m.map(e=>(0,i.jsxs)(h,{onClick:()=>n(e.code),children:[(0,i.jsx)(u,{children:e.flagIcon}),(0,i.jsx)(x,{children:e.abbr})]},e.code))})]})};n()}catch(e){n(e)}})},7843:e=>{e.exports=import("react-i18next")},8732:e=>{e.exports=require("react/jsx-runtime")},9380:(e,t,r)=>{Object.defineProperty(t,"__esModule",{value:!0}),Object.defineProperty(t,"default",{enumerable:!0,get:function(){return l}});let n=r(7020),i=r(8732),o=n._(r(2015)),a=r(6370);async function s(e){let{Component:t,ctx:r}=e;return{pageProps:await (0,a.loadGetInitialProps)(t,r)}}class l extends o.default.Component{render(){let{Component:e,pageProps:t}=this.props;return(0,i.jsx)(e,{...t})}}l.origGetInitialProps=s,l.getInitialProps=s,("function"==typeof t.default||"object"==typeof t.default&&null!==t.default)&&void 0===t.default.__esModule&&(Object.defineProperty(t.default,"__esModule",{value:!0}),Object.assign(t.default,t),e.exports=t.default)}};var t=require("../webpack-runtime.js");t.C(e);var r=e=>t(t.s=e),n=t.X(0,[548],()=>r(1773));module.exports=n})();