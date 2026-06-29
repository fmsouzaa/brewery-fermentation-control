// Sidebar.tsx - Menu lateral de navegação
import { Link } from 'react-router-dom'
import logo from '../../assets/logo.svg'
import styles from './Sidebar.module.css'

interface SidebarProps {
  isOpen: boolean
  onClose: () => void
}

const Sidebar = ({ isOpen, onClose }: SidebarProps) => {
  return (
    <aside className={`${styles.sidebar} ${isOpen ? styles.sidebarOpen : ''}`}>
      {/* Botão fechar - só aparece no mobile quando sidebar está aberta */}
      <button className={styles.closeButton} onClick={onClose}>
        ✕
      </button>
      
      {/* Logo */}
      <div className={styles.logoContainer}>
        <img src={logo} alt="ArBrain" className={styles.logo} />
      </div>

      {/* Links de navegação */}
      <nav className={styles.nav}>
        <Link to="/dashboard" className={styles.link} onClick={onClose}>Dashboard</Link>
        <Link to="/beers" className={styles.link} onClick={onClose}>Cervejas</Link>
        <Link to="/tanks" className={styles.link} onClick={onClose}>Tanques</Link>
        <Link to="/parameters" className={styles.link} onClick={onClose}>Parâmetros</Link>
        <Link to="/fermentation" className={styles.link} onClick={onClose}>Fermentação</Link>
        <Link to="/history" className={styles.link} onClick={onClose}>Histórico</Link>
      </nav>
    </aside>
  )
}

export default Sidebar