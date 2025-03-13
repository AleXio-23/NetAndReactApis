'use client';

import React, { useEffect } from 'react';
import AnimatedBackground from '@/components/AnimatedBackground';
import { usePathname } from 'next/navigation';

interface ProvidersProps {
  children: React.ReactNode;
}

export const Providers: React.FC<ProvidersProps> = ({ children }) => {
  const pathname = usePathname();
  
  useEffect(() => {
    console.log("Current pathname:", pathname);
  }, [pathname]);

  // Always show background for now to debug the issue
  const showBackground = true;
  
  // Original condition (uncomment after confirming background works)
  // const showBackground = pathname === '/' || 
  //                       pathname.includes('/dashboard') || 
  //                       pathname.includes('/signin') || 
  //                       pathname.includes('/sign-in') ||
  //                       pathname === '/signin' ||
  //                       pathname === '/sign-in';
  
  return (
    <>
      {showBackground && <AnimatedBackground />}
      {children}
    </>
  );
};

export default Providers; 