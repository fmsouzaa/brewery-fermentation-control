// Sidebar.tsx - Menu lateral de navegação
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
        <a href="/dashboard" className={styles.link}>Dashboard</a>
        <a href="/beers" className={styles.link}>Cervejas</a>
        <a href="/tanks" className={styles.link}>Tanques</a>
        <a href="/parameters" className={styles.link}>Parâmetros</a>
        <a href="/fermentation" className={styles.link}>Fermentação</a>
        <a href="/history" className={styles.link}>Histórico</a>
      </nav>
    </aside>
  )
}

export default Sidebar