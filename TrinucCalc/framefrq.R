args <- commandArgs(TRUE)

setwd("/home/alvydas/Oligonucleotides/TrinucCalc")
getwd()
list.files()

cdsframe <- read.table(args[1])
cdsframe
ncdsframe <- read.table(args[2])
ncdsframe

pdf("TrinucCalc.pdf", width=20, height=10)

#boxplot of cds frames
boxplot(cdsframe$V2, cdsframe$V3, cdsframe$V4, cdsframe$V5,
        main="CDS trinuc frq diff",
        boxwex=0.3,
        las=1,
        col="light blue"
        )
        grid(col="blue")

boxplot(cdsframe$V2, ncdsframe$V2,
        cdsframe$V3, ncdsframe$V3,
        cdsframe$V4, ncdsframe$V4,
        cdsframe$V5, ncdsframe$V5,
        main="E.coli trinuc frq diff. CDS vs NonCDS",
        ylab="frq diff",
        xlab="",
        colnames=c("cds1st2nd",
                   "ncds1st2nd",
                   "cds1st3rd",
                   "ncds1st3rd",
                   "cds2nd3rd",
                   "noncds2nd",
                   "cdsdiff",
                   "noncdfdiff"),
        boxwex=0.3,
        #rotate_x(colnames, 'mpg', 45)
        las=2,
        col="lightblue"
        )
        grid(col="black")
        
x <- c(1:length(cdsframe$V2)); y <- cdsframe$V2
plot(x, y, col="blue")
par(col="blue")
lines(x, y, type="h")

dev.off()

system("zathura TrinucCalc.pdf")