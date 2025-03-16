exports.id=902,exports.ids=[902],exports.modules={440:(e,t,r)=>{"use strict";r.r(t),r.d(t,{default:()=>n});var o=r(1658);let n=async e=>[{type:"image/x-icon",sizes:"16x16",url:(0,o.fillMetadataSegment)(".",await e.params,"favicon.ico")+""}]},565:(e,t,r)=>{"use strict";r.d(t,{D:()=>l,ThemeProvider:()=>d});var o=r(687),n=r(3210),i=r(7237);let s={primary:"#7c3aed",secondary:"#3b82f6",background:"linear-gradient(135deg, rgba(255,255,255,0.9) 0%, rgba(249,250,251,0.95) 100%)",cardBackground:"#f9fafb",text:"#111827",inputBorder:"#d1d5db",inputBackground:"#ffffff",buttonText:"#ffffff",isDark:!1},a={primary:"#8b5cf6",secondary:"#60a5fa",background:"linear-gradient(135deg, rgba(17,24,39,0.9) 0%, rgba(31,41,55,0.95) 100%)",cardBackground:"#1f2937",text:"#f9fafb",inputBorder:"#374151",inputBackground:"#1f2937",buttonText:"#ffffff",isDark:!0},l=(0,n.createContext)({theme:s,toggleTheme:()=>{}}),d=({children:e})=>{let[t,r]=(0,n.useState)(!1);(0,n.useEffect)(()=>{let e=localStorage.getItem("theme");e?r("dark"===e):r(window.matchMedia&&window.matchMedia("(prefers-color-scheme: dark)").matches)},[]),(0,n.useEffect)(()=>{t?document.body.setAttribute("data-theme","dark"):document.body.setAttribute("data-theme","light")},[t]);let d=t?a:s;return(0,o.jsx)(l.Provider,{value:{theme:d,toggleTheme:()=>{r(!t),localStorage.setItem("theme",t?"light":"dark")}},children:(0,o.jsx)(i.NP,{theme:d,children:e})})}},751:(e,t,r)=>{Promise.resolve().then(r.t.bind(r,6346,23)),Promise.resolve().then(r.t.bind(r,7924,23)),Promise.resolve().then(r.t.bind(r,5656,23)),Promise.resolve().then(r.t.bind(r,99,23)),Promise.resolve().then(r.t.bind(r,8243,23)),Promise.resolve().then(r.t.bind(r,8827,23)),Promise.resolve().then(r.t.bind(r,2763,23)),Promise.resolve().then(r.t.bind(r,7173,23))},1135:()=>{},1298:(e,t,r)=>{"use strict";r.d(t,{default:()=>a});var o=r(687),n=r(3210),i=r(6189),s=r(7237);function a({children:e}){let[t]=(0,n.useState)(()=>new s.E);return(0,i.useServerInsertedHTML)(()=>{let e=t.getStyleElement();return t.instance.clearTag(),(0,o.jsx)(o.Fragment,{children:e})}),(0,o.jsx)(s.ID,{sheet:t.instance,children:e})}},1949:(e,t,r)=>{"use strict";r.d(t,{U:()=>d});var o=r(687),n=r(3210),i=r(7237),s=r(565),a=r(6457);let l=i.Ay.button`
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
`,d=()=>{let{theme:e,toggleTheme:t}=(0,n.useContext)(s.D),{t:r}=(0,a.Bd)();return(0,o.jsx)(l,{onClick:t,"aria-label":r("header.darkMode"),children:e.isDark?"☀️":"\uD83C\uDF19"})}},2685:(e,t,r)=>{"use strict";r.d(t,{default:()=>h});var o=r(687),n=r(3210),i=r(7237),s=r(565);let a=(0,i.i7)`
  0% {
    transform: translateY(0) translateX(0);
    opacity: 0.14;
  }
  50% {
    transform: translateY(-60px) translateX(10px);
    opacity: 0.56;
  }
  100% {
    transform: translateY(-120px) translateX(20px);
    opacity: 0.14;
  }
`,l=i.Ay.div`
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  overflow: hidden;
  pointer-events: none;
  z-index: 0;
`,d=i.Ay.div`
  position: absolute;
  bottom: ${e=>e.$positionY}%;
  left: ${e=>e.$positionX}%;
  width: ${e=>e.$size}px;
  height: ${e=>e.$size}px;
  border-radius: 50%;
  background-color: ${e=>e.$color};
  opacity: 0.14;
  animation: ${a} ${e=>e.$duration}s ease-in-out ${e=>e.$delay}s infinite;
  box-shadow: 0 0 15px ${e=>e.$color}88;
`,f=()=>{let[e,t]=(0,n.useState)([]),{theme:r}=(0,n.useContext)(s.D);return(0,n.useEffect)(()=>{let e=r.isDark?[r.primary,r.secondary,"#9333ea","#6366f1","#a855f7","#ffffff33","#ec4899aa"]:[r.primary,r.secondary,`${r.primary}EE`,`${r.secondary}EE`,"#00000033","#3b82f699","#7c3aed99"],n=Array.from({length:70}).map((t,r)=>{let n=25*Math.random()+10,i=100*Math.random(),s=100*Math.random(),a=10*Math.random(),l=15*Math.random()+15,f=e[Math.floor(Math.random()*e.length)];return(0,o.jsx)(d,{$size:n,$positionX:i,$positionY:s,$delay:a,$duration:l,$color:f},r)});t(n),console.log("Animated background initialized with",n.length,"bubbles in",r.isDark?"dark":"light","mode")},[r]),(0,o.jsx)("div",{id:"background-wrapper",children:(0,o.jsx)(l,{children:e})})};var c=r(6189);let h=({children:e})=>{let t=(0,c.usePathname)();return(0,n.useEffect)(()=>{console.log("Current pathname:",t)},[t]),(0,o.jsxs)(o.Fragment,{children:[(0,o.jsx)(f,{}),e]})}},3959:(e,t,r)=>{Promise.resolve().then(r.t.bind(r,6444,23)),Promise.resolve().then(r.t.bind(r,6042,23)),Promise.resolve().then(r.t.bind(r,8170,23)),Promise.resolve().then(r.t.bind(r,9477,23)),Promise.resolve().then(r.t.bind(r,9345,23)),Promise.resolve().then(r.t.bind(r,2089,23)),Promise.resolve().then(r.t.bind(r,6577,23)),Promise.resolve().then(r.t.bind(r,1307,23))},4347:(e,t,r)=>{"use strict";r.d(t,{ThemeProvider:()=>n});var o=r(2907);(0,o.registerClientReference)(function(){throw Error("Attempted to call ThemeContext() from the server but ThemeContext is on the client. It's not possible to invoke a client function from the server, it can only be rendered as a Component or passed to props of a Client Component.")},"C:\\Users\\Aleksandre\\Desktop\\NetAndReactApis\\Front\\NorthernLight\\auroraflow\\src\\theme\\ThemeProvider.tsx","ThemeContext");let n=(0,o.registerClientReference)(function(){throw Error("Attempted to call ThemeProvider() from the server but ThemeProvider is on the client. It's not possible to invoke a client function from the server, it can only be rendered as a Component or passed to props of a Client Component.")},"C:\\Users\\Aleksandre\\Desktop\\NetAndReactApis\\Front\\NorthernLight\\auroraflow\\src\\theme\\ThemeProvider.tsx","ThemeProvider")},4431:(e,t,r)=>{"use strict";r.r(t),r.d(t,{default:()=>m,metadata:()=>p});var o=r(7413),n=r(2376),i=r.n(n),s=r(8726),a=r.n(s),l=r(1326),d=r.n(l);r(1135);var f=r(5020),c=r(4347),h=r(9519);let p={title:"AuroraFlow",description:"AuroraFlow Project"};function m({children:e}){return(0,o.jsx)("html",{lang:"en",className:`${i().variable} ${a().variable} ${d().variable} antialiased`,children:(0,o.jsx)("body",{children:(0,o.jsx)(f.default,{children:(0,o.jsx)(c.ThemeProvider,{children:(0,o.jsx)(h.default,{children:e})})})})})}},5020:(e,t,r)=>{"use strict";r.d(t,{default:()=>o});let o=(0,r(2907).registerClientReference)(function(){throw Error("Attempted to call the default export of \"C:\\\\Users\\\\Aleksandre\\\\Desktop\\\\NetAndReactApis\\\\Front\\\\NorthernLight\\\\auroraflow\\\\src\\\\app\\\\registry.tsx\" from the server, but it's on the client. It's not possible to invoke a client function from the server, it can only be rendered as a Component or passed to props of a Client Component.")},"C:\\Users\\Aleksandre\\Desktop\\NetAndReactApis\\Front\\NorthernLight\\auroraflow\\src\\app\\registry.tsx","default")},5581:(e,t,r)=>{"use strict";r.d(t,{G:()=>u});var o=r(687),n=r(3210),i=r.n(n),s=r(7237),a=r(6457);let l=s.Ay.div`
  position: relative;
  margin-left: 1rem;
`,d=s.Ay.button`
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
`,f=s.Ay.div`
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
`,c=s.Ay.button`
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
`,h=s.Ay.span`
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
`;s.Ay.div`
  display: flex;
  align-items: center;
  width: 100%;
  justify-content: space-between;
`;let p=s.Ay.span`
  font-weight: 400;
`,m=[{code:"en",abbr:"ENG",flagIcon:(0,o.jsx)(()=>(0,o.jsxs)("svg",{xmlns:"http://www.w3.org/2000/svg",viewBox:"0 0 1235 650",children:[(0,o.jsx)("rect",{width:"1235",height:"650",fill:"#bf0a30"}),(0,o.jsx)("rect",{width:"1235",height:"50",fill:"#ffffff",y:"50"}),(0,o.jsx)("rect",{width:"1235",height:"50",fill:"#ffffff",y:"150"}),(0,o.jsx)("rect",{width:"1235",height:"50",fill:"#ffffff",y:"250"}),(0,o.jsx)("rect",{width:"1235",height:"50",fill:"#ffffff",y:"350"}),(0,o.jsx)("rect",{width:"1235",height:"50",fill:"#ffffff",y:"450"}),(0,o.jsx)("rect",{width:"1235",height:"50",fill:"#ffffff",y:"550"}),(0,o.jsx)("rect",{width:"494",height:"350",fill:"#002868"}),(0,o.jsxs)("g",{fill:"#ffffff",children:[Array.from({length:5}).map((e,t)=>Array.from({length:6}).map((e,r)=>(0,o.jsx)("circle",{cx:41+82*r,cy:35+70*t,r:"19"},`${t}-${r}`))),Array.from({length:4}).map((e,t)=>Array.from({length:5}).map((e,r)=>(0,o.jsx)("circle",{cx:82+82*r,cy:70+70*t,r:"19"},`extra-${t}-${r}`)))]})]}),{})},{code:"ru",abbr:"RUS",flagIcon:(0,o.jsx)(()=>(0,o.jsxs)("svg",{xmlns:"http://www.w3.org/2000/svg",viewBox:"0 0 9 6",children:[(0,o.jsx)("rect",{fill:"#fff",width:"9",height:"3"}),(0,o.jsx)("rect",{fill:"#d52b1e",y:"3",width:"9",height:"3"}),(0,o.jsx)("rect",{fill:"#0039a6",y:"2",width:"9",height:"2"})]}),{})},{code:"ka",abbr:"GEO",flagIcon:(0,o.jsx)(()=>(0,o.jsxs)("svg",{xmlns:"http://www.w3.org/2000/svg",viewBox:"0 0 300 200",children:[(0,o.jsx)("rect",{width:"300",height:"200",fill:"#fff"}),(0,o.jsx)("path",{d:"M 130,0 L 170,0 L 170,80 L 300,80 L 300,120 L 170,120 L 170,200 L 130,200 L 130,120 L 0,120 L 0,80 L 130,80 Z",fill:"#ff0000"}),(0,o.jsx)("path",{d:"M 50,50 L 80,50 L 80,30 L 100,30 L 100,50 L 130,50 L 130,70 L 100,70 L 100,90 L 80,90 L 80,70 L 50,70 Z",fill:"#ff0000"}),(0,o.jsx)("path",{d:"M 200,50 L 230,50 L 230,30 L 250,30 L 250,50 L 280,50 L 280,70 L 250,70 L 250,90 L 230,90 L 230,70 L 200,70 Z",fill:"#ff0000"}),(0,o.jsx)("path",{d:"M 50,150 L 80,150 L 80,130 L 100,130 L 100,150 L 130,150 L 130,170 L 100,170 L 100,190 L 80,190 L 80,170 L 50,170 Z",fill:"#ff0000"}),(0,o.jsx)("path",{d:"M 200,150 L 230,150 L 230,130 L 250,130 L 250,150 L 280,150 L 280,170 L 250,170 L 250,190 L 230,190 L 230,170 L 200,170 Z",fill:"#ff0000"})]}),{})}],u=()=>{let{i18n:e}=(0,a.Bd)(),[t,r]=i().useState(!1),n=t=>{e.changeLanguage(t),r(!1)},s=m.find(t=>t.code===e.language)||m[0];return(0,o.jsxs)(l,{children:[(0,o.jsxs)(d,{onClick:()=>{r(!t)},children:[(0,o.jsx)(h,{children:s.flagIcon}),s.abbr]}),(0,o.jsx)(f,{$isOpen:t,children:m.map(e=>(0,o.jsxs)(c,{onClick:()=>n(e.code),children:[(0,o.jsx)(h,{children:e.flagIcon}),(0,o.jsx)(p,{children:e.abbr})]},e.code))})]})}},6305:(e,t,r)=>{Promise.resolve().then(r.bind(r,2685)),Promise.resolve().then(r.bind(r,1298)),Promise.resolve().then(r.bind(r,565))},9519:(e,t,r)=>{"use strict";r.d(t,{default:()=>n});var o=r(2907);(0,o.registerClientReference)(function(){throw Error("Attempted to call Providers() from the server but Providers is on the client. It's not possible to invoke a client function from the server, it can only be rendered as a Component or passed to props of a Client Component.")},"C:\\Users\\Aleksandre\\Desktop\\NetAndReactApis\\Front\\NorthernLight\\auroraflow\\src\\app\\providers.tsx","Providers");let n=(0,o.registerClientReference)(function(){throw Error("Attempted to call the default export of \"C:\\\\Users\\\\Aleksandre\\\\Desktop\\\\NetAndReactApis\\\\Front\\\\NorthernLight\\\\auroraflow\\\\src\\\\app\\\\providers.tsx\" from the server, but it's on the client. It's not possible to invoke a client function from the server, it can only be rendered as a Component or passed to props of a Client Component.")},"C:\\Users\\Aleksandre\\Desktop\\NetAndReactApis\\Front\\NorthernLight\\auroraflow\\src\\app\\providers.tsx","default")},9857:(e,t,r)=>{Promise.resolve().then(r.bind(r,9519)),Promise.resolve().then(r.bind(r,5020)),Promise.resolve().then(r.bind(r,4347))}};