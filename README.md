# ChronoSyncAPI
Als stagiair bij Xylos ga ik de uitdaging aan om hun huidige tool voor werkurenregistratie (Omnitracker) om te toveren  
tot een moderne en efficiënte applicatie. Om dit te volbrengen, ga ik aan de slag met Power Apps en Power Automate.  

---------------------------------------------------------------
This Testing API is designed to serve as the backbone for the modernization of Xylos' work hours registration tool, Omnitracker.  
As an intern at Xylos, I am tasked with transforming this legacy tool into a modern, efficient application using Power Apps and Power Automate.  
The goal is to improve the usability, integration, and automation of work hour tracking, enabling a smoother workflow for employees.  
This testing API will ensure seamless communication between various systems while providing reliable data to streamline the work hour registration process.  
The project is called ChronoSync as in synchronized with time (Greek translation of chronos).  

## Routes
### Activity
| Method | URL                                                     |
| ------ | ------------------------------------------------------- |
| GET    | /api/v1/Activity                                        |
| GET    | /api/v1/Activity/{activityId}                           |
| GET    | /api/v1/Activity/{activityId}/timeentries               |
| POST   | /api/v1/Activity/{activityId}/timeentries               |
| GET    | /api/v1/Activity/{activityId}/timeentries/{timeEntryId} |
| PUT    | /api/v1/Activity/{activityId}/timeentries/{timeEntryId} |
| DELETE | /api/v1/Activity/{activityId}/timeentries/{timeEntryId} |

### AdminActivity
| Method | URL                                                          |
| ------ | ------------------------------------------------------------ |
| GET    | /api/v1/AdminActivity                                        |
| GET    | /api/v1/AdminActivity/{id}                                   |
| GET    | /api/v1/AdminActivity/{activityId}/timeentries               |
| POST   | /api/v1/AdminActivity/{activityId}/timeentries               |
| GET    | /api/v1/AdminActivity/{activityId}/timeentries/{timeEntryId} |
| PUT    | /api/v1/AdminActivity/{activityId}/timeentries/{timeEntryId} |
| DELETE | /api/v1/AdminActivity/{activityId}/timeentries/{timeEntryId} |

### DetachedTimeEntry
| Method | URL                            |
| ------ | ------------------------------ |
| GET    | /api/v1/DetachedTimeEntry      |
| GET    | /api/v1/DetachedTimeEntry/{id} |

### TimeEntry
| Method | URL                    |
| ------ | ---------------------- |
| GET    | /api/v1/TimeEntry      |
| GET    | /api/v1/TimeEntry/{id} |

### User
| Method | URL               |
| ------ | ----------------- |
| GET    | /api/v1/User      |
| GET    | /api/v1/User/{id} |

http://localhost:8080/swagger/index.html