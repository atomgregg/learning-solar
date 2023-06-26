// Composables
import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    component: () => import('@/layouts/default/Default.vue'),
    children: [
      {
        path: '/',
        name: 'Home',
        component: () => import('@/views/Home.vue'),
      },
      {
        path: '/projects',
        component: () => import('@/views/Projects.vue'),
        children: [
          {
            path: '/projects',
            name: 'ProjectList',
            component: () => import('@/views/projects/ProjectList.vue'),
          },{
            path: '/projects/homesolarmonitoring',
            name: 'ProjectHomeSolarMonitoring',
            component: () => import('@/views/projects/HomeSolarMonitoring.vue'),
          },
        ]
      },
      {
        path: '/blogs',
        component: () => import('@/views/Blogs.vue'),
        children: [
          {
            path: '/blogs',
            name: 'BlogList',
            component: () => import('@/views/blogs/BlogList.vue'),
          },{
            path: '/blogs/comingsoon',
            name: 'ComingSoon',
            component: () => import('@/views/blogs/ComingSoon.vue'),
          },
        ]
      },
    ],
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
})

export default router
