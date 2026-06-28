// Sidebar.tsx - Menu lateral de navegação
import { Link } from 'react-router-dom'
import logo from '../../assets/logo.svg'
import styles from './Sidebar.module.css'

const Sidebar = () => {
  return (
    <aside className={styles.sidebar}>
      {/* Logo */}
      <div className={styles.logoContainer}>
        <img src={logo} alt="ArBrain" className={styles.logo} />
      </div>

      {/* Links de navegação */}
      <nav className={styles.nav}>
        <Link to="/dashboard" className={styles.link}>Dashboard</Link>
        <Link to="/beers" className={styles.link}>Cervejas</Link>
        <Link to="/tanks" className={styles.link}>Tanques</Link>
        <Link to="/parameters" className={styles.link}>Parâmetros</Link>
        <Link to="/fermentation" className={styles.link}>Fermentação</Link>
        <Link to="/history" className={styles.link}>Histórico</Link>
      </nav>
    </aside>
  )
}

export default Sidebar