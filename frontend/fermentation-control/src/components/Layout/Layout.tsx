// Layout.tsx - Estrutura base que envolve todas as páginas
import type React from 'react'
import { useState } from 'react'
import Sidebar from './Sidebar'
import styles from './Layout.module.css'

interface LayoutProps {
  children: React.ReactNode
}

const Layout = ({ children }: LayoutProps) => {
  const [isOpen, setIsOpen] = useState(false)

  return (
    <div className={styles.container}>

      {/* Topbar mobile */}
      <div className={styles.topbar}>
        <button className={styles.hamburger} onClick={() => setIsOpen(!isOpen)}>
          {isOpen ? '✕' : '☰'}
        </button>
      </div>

      {/* Overlay */}
      {isOpen && (
        <div className={styles.overlay} onClick={() => setIsOpen(false)} />
      )}

      <Sidebar isOpen={isOpen} onClose={() => setIsOpen(false)} />

      <main className={styles.content}>
        {children}
      </main>
    </div>
  )
}

export default Layout