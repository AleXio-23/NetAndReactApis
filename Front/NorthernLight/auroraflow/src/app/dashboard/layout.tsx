'use client';

import { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import ClientOnly from '@/components/ClientOnly';

// This is a basic auth check - replace with your actual auth logic
const useAuthCheck = () => {
  // For demonstration, we'll consider the user is logged in
  // In a real app, this would check for a valid auth token/session
  return { isAuthenticated: true, isLoading: false, user: { name: 'Alex', initials: 'A' } };
};

export default function DashboardLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  const router = useRouter();
  const { isAuthenticated, isLoading } = useAuthCheck();
  
  useEffect(() => {
    // Redirect to login if not authenticated and not loading
    if (!isLoading && !isAuthenticated) {
      router.push('/signin');
    }
    
    // Set a flag in localStorage to indicate user is authenticated
    // This can be used by other components to adjust UI
    if (isAuthenticated) {
      localStorage.setItem('isAuthenticated', 'true');
    }
  }, [isAuthenticated, isLoading, router]);
  
  // Don't show anything while checking authentication
  if (isLoading) {
    return <div>Loading...</div>;
  }
  
  // Use ClientOnly to prevent hydration errors
  return (
    <ClientOnly>
      {isAuthenticated ? children : null}
    </ClientOnly>
  );
} 