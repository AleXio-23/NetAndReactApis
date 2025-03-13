'use client';

import React, { useState, useEffect, useContext } from 'react';
import styled, { keyframes } from 'styled-components';
import { ThemeContext } from '@/theme/ThemeProvider';

const floatAnimation = keyframes`
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
`;

const BubbleContainer = styled.div`
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  overflow: hidden;
  pointer-events: none;
  z-index: 0;
`;

interface BubbleProps {
  size: number;
  positionX: number;
  positionY: number;
  delay: number;
  duration: number;
  color: string;
}

const Bubble = styled.div<BubbleProps>`
  position: absolute;
  bottom: ${props => props.positionY}%;
  left: ${props => props.positionX}%;
  width: ${props => props.size}px;
  height: ${props => props.size}px;
  border-radius: 50%;
  background-color: ${props => props.color};
  opacity: 0.14;
  animation: ${floatAnimation} ${props => props.duration}s ease-in-out ${props => props.delay}s infinite;
  box-shadow: 0 0 15px ${props => props.color}88;
`;

export const AnimatedBackground: React.FC = () => {
  const [bubbles, setBubbles] = useState<React.ReactNode[]>([]);
  const { theme } = useContext(ThemeContext);
  
  useEffect(() => {
    // Use colors from the theme with distinct options for dark mode
    const colors = theme.isDark 
      ? [
          theme.primary,
          theme.secondary,
          '#9333ea', // purple-600
          '#6366f1', // indigo-500
          '#a855f7', // purple-500
          '#ffffff33', // subtle white
          '#ec4899aa', // pink with transparency
        ]
      : [
          theme.primary,
          theme.secondary,
          `${theme.primary}EE`,
          `${theme.secondary}EE`,
          '#00000033', // subtle black
          '#3b82f699', // blue with transparency
          '#7c3aed99', // violet with transparency
        ];
    
    const newBubbles = Array.from({ length: 70 }).map((_, i) => {
      const size = Math.random() * 25 + 10; // Size between 10-35px
      const positionX = Math.random() * 100; // Horizontal position (0-100%)
      const positionY = Math.random() * 100; // Vertical position (0-100%)
      const delay = Math.random() * 10; // More varied delays
      const duration = Math.random() * 15 + 15; // Duration between 15-30s for smoother, slower movement
      const color = colors[Math.floor(Math.random() * colors.length)];
      
      return (
        <Bubble 
          key={i}
          size={size}
          positionX={positionX}
          positionY={positionY}
          delay={delay}
          duration={duration}
          color={color}
        />
      );
    });
    
    setBubbles(newBubbles);

    console.log("Animated background initialized with", newBubbles.length, "bubbles in", theme.isDark ? "dark" : "light", "mode");
  }, [theme]); // Recreate bubbles when theme changes
  
  return (
    <div id="background-wrapper">
      <BubbleContainer>{bubbles}</BubbleContainer>
    </div>
  );
};

export default AnimatedBackground; 