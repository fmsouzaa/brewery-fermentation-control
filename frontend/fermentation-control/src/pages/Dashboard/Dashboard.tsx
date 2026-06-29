// Dashboard.tsx - Tela inicial com indicadores de fermentação
import { useEffect, useState } from 'react'
import type { DashboardData  } from '../../types/Dashboard'
import { getDashboard } from '../../services/dashboardService'
import styles from './Dashboard.module.css'

const Dashboard = () => {
  // Estado para armazenar os dados do dashboard
  const [data, setData] = useState<DashboardData  | null>(null)

  // Busca os dados da API quando a página carrega
  useEffect(() => {
    getDashboard().then(response => {
      setData(response.data)
    })
  }, [])

  // Enquanto os dados não chegam, mostra loading
  if (!data) return <div className={styles.loading}>Carregando...</div>

  //Cards dos totais das categorias.
  return (
    <div className={styles.container}>
      <h1 className={styles.title}>Dashboard</h1>

      <div className={styles.cards}>
        <div className={`${styles.card} ${styles.cardTotal}`}>
        <span className={styles.cardLabel}>Total de Registros</span>
        <span className={styles.cardValue}>{data.totalRecords}</span>
      </div>

      <div className={`${styles.card} ${styles.cardGreen}`}>
        <span className={styles.cardLabel}>Dentro do Padrão</span>
        <span className={styles.cardValue}>{data.withinStandardCount}</span>
      </div>

      <div className={`${styles.card} ${styles.cardYellow}`}>
        <span className={styles.cardLabel}>Atenção</span>
        <span className={styles.cardValue}>{data.attentionCount}</span>
      </div>

      <div className={`${styles.card} ${styles.cardRed}`}>
        <span className={styles.cardLabel}>Fora do Padrão</span>
        <span className={styles.cardValue}>{data.outOfStandardCount}</span>
      </div>
    </div>
  </div>
  )
}

export default Dashboard