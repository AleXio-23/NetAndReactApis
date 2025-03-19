'use client';

import React, { useEffect, useState } from 'react';
import AnimatedBackground from '@/components/AnimatedBackground';
import { usePathname } from 'next/navigation';
import ClientOnly from '@/components/ClientOnly';
import I18nProvider from '@/components/I18nProvider';

interface ProvidersProps {
  children: React.ReactNode;
}

export const Providers: React.FC<ProvidersProps> = ({ children }) => {
  const pathname = usePathname();
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  
  useEffect(() => {
    // Check if the user is authenticated from localStorage
    const authStatus = localStorage.getItem('isAuthenticated') === 'true';
    setIsAuthenticated(authStatus);
    
    // Listen for auth changes
    const handleStorageChange = () => {
      const newAuthStatus = localStorage.getItem('isAuthenticated') === 'true';
      setIsAuthenticated(newAuthStatus);
    };
    
    window.addEventListener('storage', handleStorageChange);
    return () => {
      window.removeEventListener('storage', handleStorageChange);
    };
  }, []);
  
  // Check if the current page is a dashboard page (authorized page)
  const isDashboardPage = pathname?.startsWith('/dashboard');
  
  // Only show background if:
  // 1. User is not authenticated OR
  // 2. Not on a dashboard page (even if authenticated)
  const showBackground = !isAuthenticated || !isDashboardPage;
  
  return (
    <ClientOnly>
      <I18nProvider>
        <>
          {showBackground && (
            <AnimatedBackground />
          )}
          {children}
        </>
      </I18nProvider>
    </ClientOnly>
  );
};

export default Providers; 