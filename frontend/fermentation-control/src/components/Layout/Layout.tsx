// Layout.tsx - Estrutura base que envolve todas as páginas
import type React from 'react'
import Sidebar from './Sidebar'
import styles from './Layout.module.css'

interface LayoutProps {
  children: React.ReactNode
}

const Layout = ({ children }: LayoutProps) => {
  return (
    <div className={styles.container}>
      <Sidebar />
      <main className={styles.content}>
        {children}
      </main>
    </div>
  )
}

export default Layout