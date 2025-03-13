'use client';

import React from 'react';
import SignIn from '@/components/SignIn';
import { ThemeProvider } from '@/theme/ThemeProvider';
import '@/i18n';

export default function SignInPage() {
  return (
    <ThemeProvider>
      <SignIn />
    </ThemeProvider>
  );
} 