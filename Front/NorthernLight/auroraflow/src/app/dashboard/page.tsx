'use client';

import React from 'react';
import styled from 'styled-components';
import { useTranslation } from 'react-i18next';
import DashboardLayout from '@/components/layouts/DashboardLayout';

const WelcomeSection = styled.div`
  margin-bottom: 2rem;
`;

const Title = styled.h1`
  font-size: 1.8rem;
  font-weight: 500;
  margin-bottom: 0.5rem;
  color: ${({ theme }) => theme.text};
`;

const Subtitle = styled.p`
  font-size: 1rem;
  color: ${({ theme }) => theme.textSecondary};
  margin-bottom: 1.5rem;
`;

const CardsContainer = styled.div`
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
  gap: 1.5rem;
  margin-bottom: 2rem;
`;

const Card = styled.div`
  background-color: ${({ theme }) => theme.cardBackground};
  border-radius: 8px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.08);
  padding: 1.5rem;
  transition: transform 0.2s ease, box-shadow 0.2s ease;
  
  &:hover {
    transform: translateY(-2px);
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  }
`;

const CardTitle = styled.h3`
  font-size: 1.1rem;
  font-weight: 500;
  margin-bottom: 0.75rem;
  color: ${({ theme }) => theme.text};
`;

const CardValue = styled.div`
  font-size: 2rem;
  font-weight: 600;
  color: ${({ theme }) => theme.primary};
  margin-bottom: 0.5rem;
`;

const CardDescription = styled.p`
  font-size: 0.9rem;
  color: ${({ theme }) => theme.textSecondary};
`;

const RecentActivitiesSection = styled.div`
  background-color: ${({ theme }) => theme.cardBackground};
  border-radius: 8px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.08);
  padding: 1.5rem;
`;

const SectionTitle = styled.h2`
  font-size: 1.2rem;
  font-weight: 500;
  margin-bottom: 1rem;
  color: ${({ theme }) => theme.text};
`;

const ActivityList = styled.div`
  display: flex;
  flex-direction: column;
  gap: 0.75rem;
`;

const ActivityItem = styled.div`
  display: flex;
  align-items: center;
  padding: 0.75rem;
  border-radius: 6px;
  background-color: ${({ theme }) => theme.backgroundPrimary};
  
  &:hover {
    background-color: ${({ theme }) => theme.backgroundSecondary};
  }
`;

const ActivityIcon = styled.div`
  width: 36px;
  height: 36px;
  border-radius: 6px;
  background-color: ${({ theme }) => theme.primary}20;
  color: ${({ theme }) => theme.primary};
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 1.1rem;
  margin-right: 1rem;
`;

const ActivityContent = styled.div`
  flex: 1;
`;

const ActivityTitle = styled.div`
  font-size: 0.95rem;
  font-weight: 500;
  margin-bottom: 0.25rem;
  color: ${({ theme }) => theme.text};
`;

const ActivityMeta = styled.div`
  font-size: 0.8rem;
  color: ${({ theme }) => theme.textSecondary};
`;

const DashboardPage: React.FC = () => {
  const { t, i18n } = useTranslation();
  const [, forceUpdate] = React.useState({});
  
  // Force re-render when language changes to update all translations
  React.useEffect(() => {
    const handleLanguageChanged = () => {
      forceUpdate({});
    };
    
    i18n.on('languageChanged', handleLanguageChanged);
    
    return () => {
      i18n.off('languageChanged', handleLanguageChanged);
    };
  }, [i18n]);
  
  // Example data
  const metrics = [
    { title: t('dashboard.totalProjects'), value: 12, description: t('dashboard.activeProjects') },
    { title: t('dashboard.completedTasks'), value: 48, description: t('dashboard.tasksThisWeek') },
    { title: t('dashboard.teamMembers'), value: 8, description: t('dashboard.activeMembersCount') },
    { title: t('dashboard.upcomingDeadlines'), value: 5, description: t('dashboard.nextSevenDays') },
  ];
  
  const activities = [
    { 
      icon: '📝', 
      title: t('dashboard.taskCreated', { task: 'Homepage Redesign' }), 
      time: '2 hours ago', 
      user: 'Alex' 
    },
    { 
      icon: '✅', 
      title: t('dashboard.taskCompleted', { task: 'API Integration' }), 
      time: '4 hours ago', 
      user: 'Maria' 
    },
    { 
      icon: '💬', 
      title: t('dashboard.commentAdded', { task: 'User Authentication' }), 
      time: 'Yesterday', 
      user: 'John' 
    },
    { 
      icon: '🔄', 
      title: t('dashboard.statusChanged', { task: 'Database Migration', status: 'In Progress' }), 
      time: 'Yesterday', 
      user: 'Sarah' 
    },
    { 
      icon: '👤', 
      title: t('dashboard.memberJoined', { name: 'David' }), 
      time: '3 days ago', 
      user: 'System' 
    },
  ];
  
  return (
    <DashboardLayout>
      <WelcomeSection>
        <Title>{t('dashboard.welcomeTitle')}</Title>
        <Subtitle>{t('dashboard.welcomeSubtitle')}</Subtitle>
      </WelcomeSection>
      
      <CardsContainer>
        {metrics.map((metric, index) => (
          <Card key={index}>
            <CardTitle>{metric.title}</CardTitle>
            <CardValue>{metric.value}</CardValue>
            <CardDescription>{metric.description}</CardDescription>
          </Card>
        ))}
      </CardsContainer>
      
      <RecentActivitiesSection>
        <SectionTitle>{t('dashboard.recentActivities')}</SectionTitle>
        <ActivityList>
          {activities.map((activity, index) => (
            <ActivityItem key={index}>
              <ActivityIcon>{activity.icon}</ActivityIcon>
              <ActivityContent>
                <ActivityTitle>{activity.title}</ActivityTitle>
                <ActivityMeta>{activity.time} • {activity.user}</ActivityMeta>
              </ActivityContent>
            </ActivityItem>
          ))}
        </ActivityList>
      </RecentActivitiesSection>
    </DashboardLayout>
  );
};

export default DashboardPage; 