import React from 'react';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import { ThemeProvider } from './theme/ThemeProvider';
import SignIn from './pages/SignIn';
import './i18n';

const App: React.FC = () => {
  return (
    <ThemeProvider>
      <BrowserRouter>
        <Routes>
          {/* Redirect from root to /signin */}
          <Route path="/" element={<Navigate to="/signin" replace />} />
          
          {/* Sign In route */}
          <Route path="/signin" element={<SignIn />} />
          
          {/* Fallback route - redirect to /signin if no route matches */}
          <Route path="*" element={<Navigate to="/signin" replace />} />
        </Routes>
      </BrowserRouter>
    </ThemeProvider>
  );
};

export default App; 