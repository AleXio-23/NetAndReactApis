/** @type {import('next').NextConfig} */
const nextConfig = {
  reactStrictMode: true,
  swcMinify: true,
  compiler: {
    // Enable styled-components SSR and browser compatibility with SWC
    styledComponents: {
      displayName: true,
      ssr: true,
      minify: true
    }
  },
  // Disable Turbopack to use webpack
  experimental: {
    turbo: false,
    // Additional performance optimizations
    optimizeCss: true,
    optimizeServerReact: true
  }
};

export default nextConfig; 