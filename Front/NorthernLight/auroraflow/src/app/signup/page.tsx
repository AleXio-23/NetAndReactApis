'use client';

import React from 'react';
import SignUp from '@/components/SignUp';
import { ThemeProvider } from '@/theme/ThemeProvider';
import '@/i18n';

export default function SignUpPage() {
  return (
    <ThemeProvider>
      <SignUp />
    </ThemeProvider>
  );
} 