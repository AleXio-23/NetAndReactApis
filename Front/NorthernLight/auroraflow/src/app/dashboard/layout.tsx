'use client';

import { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import ClientOnly from '@/components/ClientOnly';

// This is a basic auth check - replace with your actual auth logic
const useAuthCheck = () => {
  // For demonstration, we'll consider the user is logged in
  // In a real app, this would check for a valid auth token/session
  return { isAuthenticated: true, isLoading: false };
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