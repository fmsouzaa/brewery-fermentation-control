// Alert.tsx
import { useEffect } from 'react'
import styles from './Alert.module.css'

interface AlertProps {
  type: 'success' | 'error'
  message: string
  onClose: () => void
}

const Alert = ({ type, message, onClose }: AlertProps) => {
  // Some automaticamente após 3 segundos
  useEffect(() => {
    const timer = setTimeout(() => {
      onClose()
    }, 5000)

    return () => clearTimeout(timer)
  }, [])

  return (
    <div className={`${styles.alert} ${styles[type]}`}>
      {message}
    </div>
  )
}

export default Alert